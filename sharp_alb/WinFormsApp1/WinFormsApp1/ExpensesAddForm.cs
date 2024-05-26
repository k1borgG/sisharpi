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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Excel;

namespace WinFormsApp1
{
    public partial class ExpensesAddForm : Form
    {
        public NpgsqlConnection conn;
        public ExpensesView form1;
        public bool IsEditMode = false;
        public int EditingproductId;

        public ExpensesAddForm(ExpensesView f, NpgsqlConnection con)
        {
            InitializeComponent();
            form1 = f;
            conn = con;
        }

        public ExpensesAddForm(NpgsqlConnection con)
        {
            InitializeComponent();
            conn = con;
        }

        public void SetEditData(int employeeId, string amount, DateTime expenseDate)
        {
            comboBox1.SelectedValue = employeeId;
            textBox1.Text = amount;
            dateTimePicker1.Value = expenseDate;


            EditingproductId = employeeId;
            IsEditMode = true;
            button1.Text = "Изменить";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
                sql = @"UPDATE Expenses SET employee_id=@employee_id, amount=@amount, date=@date
                        WHERE expense_id=@expense_id";
            }
            else
            {
                sql = @"INSERT INTO Expenses(employee_id, amount,date) 
                        VALUES (@employee_id, @amount, @date)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@employee_id", Convert.ToInt32(comboBox1.SelectedValue));
            if (decimal.TryParse(textBox1.Text, out decimal amount))
            {
                cmd.Parameters.AddWithValue("@amount", amount);
            }

            DateTime Date1 = dateTimePicker1.Value;
            cmd.Parameters.AddWithValue("@date", Date1);


            if (IsEditMode)
            {
                cmd.Parameters.AddWithValue("@expense_id", EditingproductId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            if (checkBox1.Checked)
            {
                ExportToExcel();
            }

            if (IsEditMode)
            {
                form1.loadProducts();
            }
            else
            {

                textBox1.Text = "";
            }
            
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productAddForm_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT employee_id, name FROM Employees", conn);
            adap.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "employee_id";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ExportTableToExcel(Workbook workbook, string sheetName, string sqlQuery)
        {
            Worksheet worksheet = (Worksheet)workbook.Sheets.Add();
            worksheet.Name = sheetName;

            System.Data.DataTable dt = new System.Data.DataTable();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, conn))
            {
                using (NpgsqlDataAdapter adap = new NpgsqlDataAdapter(cmd))
                {
                    adap.Fill(dt);
                }
            }

            worksheet.Cells[1, 1] = "ID сотрудника";
            worksheet.Cells[1, 2] = "Сумма";
            worksheet.Cells[1, 3] = "Дата";
            worksheet.Cells[1, 4] = "Имя";
            worksheet.Cells[1, 4] = "Отчитан";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                }
            }

            worksheet.Columns.AutoFit();
        }

        private void ExportToExcel()
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false; 

            Workbook workbook = excelApp.Workbooks.Add(Type.Missing);


            ExportTableToExcel(workbook, "CurrentExpense", $"SELECT * FROM Expenses WHERE employee_id = {comboBox1.SelectedValue} AND amount = {textBox1.Text} AND date = '{dateTimePicker1.Value}'");


            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExpenseReport.xlsx");


            workbook.SaveAs(filePath, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            workbook.Close(false, Type.Missing, Type.Missing);
            excelApp.Quit();

            MessageBox.Show($"Отчет успешно экспортирован в Excel. Путь: {filePath}", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
