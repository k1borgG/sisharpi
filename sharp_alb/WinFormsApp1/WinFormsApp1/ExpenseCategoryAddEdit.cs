using Npgsql;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ExpenseCategoryAddEdit : Form
    {
        public NpgsqlConnection conn;
        public ExpenseCategoriesView form1;
        public bool IsEditMode = false;
        public int EditingExpenseCategoryId;

        public ExpenseCategoryAddEdit(ExpenseCategoriesView f, NpgsqlConnection con)
        {
            InitializeComponent();
            form1 = f;
            conn = con;
        }

        public void SetEditData(int expenseCategoryId, string name, string cost)
        {
            textBox1.Text = name;
            textBox2.Text = cost;

            EditingExpenseCategoryId = expenseCategoryId;
            IsEditMode = true;
            button1.Text = "Изменить";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
                sql = @"UPDATE ExpenseCategories SET category_name=@name, category_cost = @cost
                        WHERE category_id=@category_id";
            }
            else
            {
                sql = @"INSERT INTO ExpenseCategories(category_name, category_cost) 
                        VALUES (@name, @cost)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            if (decimal.TryParse(textBox2.Text, out decimal cost))
            {
                cmd.Parameters.AddWithValue("@cost", cost);
            }



            if (IsEditMode)
            {
                cmd.Parameters.AddWithValue("@category_id", EditingExpenseCategoryId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            form1.LoadExpenseCategories();

            if (!IsEditMode)
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }

            IsEditMode = false;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void EmployeeAddEdit_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}