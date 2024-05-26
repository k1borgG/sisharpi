using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ExpenseCategoriesView : Form
    {
        private NpgsqlConnection con;

        public ExpenseCategoriesView(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        public void LoadExpenseCategories()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM ExpenseCategories", con);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Статья расходов";
            dataGridView1.Columns[2].HeaderText = "Цена";

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
        }

        private void expenseCategoriesView_Load(object sender, EventArgs e)
        {
            LoadExpenseCategories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpenseCategoryAddEdit ec = new ExpenseCategoryAddEdit(this, con);
            ec.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpenseCategoryAddEdit ec = new ExpenseCategoryAddEdit(this, con);

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string cost = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            ec.SetEditData(id, name, cost);
            ec.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string sql = "DELETE FROM ExpenseCategories WHERE category_id = @category_id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("category_id", id);
            cmd.ExecuteNonQuery();
            LoadExpenseCategories();
        }
    }
}