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

namespace WinFormsApp1
{
    public partial class TaxReportForm : Form
    {
        private NpgsqlConnection conn;
        public TaxReportForm(NpgsqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        private void TaxReportForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("EmployeeName", "Имя сотрудника");
            dataGridView1.Columns.Add("TaxableAmount", "Сумма облагаемая налогом");
            dataGridView1.Columns.Add("TaxAmount", "Сумма налога");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            GenerateReport(startDate, endDate);
        }

        private void GenerateReport(DateTime startDate, DateTime endDate)
        {

            dataGridView1.Rows.Clear();

            string query = @"
            SELECT 
                e.name AS EmployeeName, 
                SUM(ex.amount) AS TaxableAmount, 
                SUM(t.tax_amount) AS TaxAmount
            FROM 
                Employees e
            JOIN 
                Expenses ex ON e.employee_id = ex.employee_id
            JOIN 
                Taxes t ON ex.expense_id = t.expense_id
            WHERE 
                ex.date >= @startDate AND ex.date <= @endDate
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
                    while (reader.Read())
                    {
                        string employeeName = reader["EmployeeName"].ToString();
                        decimal taxableAmount = reader.GetDecimal(reader.GetOrdinal("TaxableAmount"));
                        decimal taxAmount = reader.GetDecimal(reader.GetOrdinal("TaxAmount"));

                        dataGridView1.Rows.Add(employeeName, taxableAmount, taxAmount);
                    }
                }
            }
        }
    }
}
