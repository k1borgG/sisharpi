using Microsoft.Office.Interop.Excel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class PieChartForm : Form
    {

        private NpgsqlConnection conn;

        public PieChartForm(NpgsqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            var selectedCategories = GetSelectedCategories();

            if (selectedCategories.Count > 0)
            {
                GenerateChart(startDate, endDate, selectedCategories);
            }
            else
            {
                MessageBox.Show("Выберите хотя бы одну статью затрат.");
            }
        }

        private void GenerateChart(DateTime startDate, DateTime endDate, List<int> selectedCategories)
        {
            // Очистка предыдущих данных
            chart1.Series.Clear();

            string categoriesList = string.Join(",", selectedCategories);
            string query = $@"
                SELECT 
                    e.name AS EmployeeName, 
                    SUM(ex.amount) AS TotalAmount
                FROM 
                    Employees e
                JOIN 
                    Expenses ex ON e.employee_id = ex.employee_id
                JOIN 
                    ExpenseCategoryMappings ecm ON ex.expense_id = ecm.expense_id
                WHERE 
                    ex.date >= @startDate AND ex.date <= @endDate
                    AND ecm.category_id IN ({categoriesList})
                GROUP BY 
                    e.name
                ORDER BY 
                    e.name;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        ChartType = SeriesChartType.Pie,
                        IsValueShownAsLabel = true
                    };

                    while (reader.Read())
                    {
                        string employeeName = reader["EmployeeName"].ToString();
                        decimal totalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount"));

                        series.Points.AddXY(employeeName, totalAmount);
                    }

                    chart1.Series.Add(series);
                }
            }
        }

        private List<int> GetSelectedCategories()
        {
            List<int> selectedCategories = new List<int>();
            foreach (DataRowView item in checkedListBox1.CheckedItems)
            {
                selectedCategories.Add((int)item["category_id"]);
            }
            return selectedCategories;
        }

        private void PieChartForm_Load(object sender, EventArgs e)
        {
            LoadExpenseCategories();
        }

        private void LoadExpenseCategories()
        {
            string sqlCategories = "SELECT category_id, category_name FROM ExpenseCategories;";
            using (NpgsqlDataAdapter adapCategories = new NpgsqlDataAdapter(sqlCategories, conn))
            {
                System.Data.DataTable dtCategories = new System.Data.DataTable();
                adapCategories.Fill(dtCategories);

                checkedListBox1.DataSource = dtCategories;
                checkedListBox1.DisplayMember = "category_name";
                checkedListBox1.ValueMember = "category_id";
            }
        }
    }
}
