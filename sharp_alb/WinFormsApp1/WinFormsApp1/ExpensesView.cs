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
    public partial class ExpensesView : Form
    {

        private NpgsqlConnection con;
        public ExpensesView(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        public void loadProducts()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap;
            adap = new NpgsqlDataAdapter(
            @"SELECT 
                e.expense_id,
                emp.name AS employee_name,
                e.amount,
                e.date,
                e.reported
            FROM 
                Expenses e
            JOIN 
                Employees emp ON e.employee_id = emp.employee_id", con);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Сумма";
            dataGridView1.Columns[3].HeaderText = "Дата";
            dataGridView1.Columns[4].HeaderText = "Отчитано ";

            dataGridView1.Columns[0].Width = 100;
        }
        private void productView_Load(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpensesAddForm ea = new ExpensesAddForm(this, con);
            ea.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpensesAddForm pr = new ExpensesAddForm(this, con);

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string amount = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DateTime date = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);



            pr.SetEditData(id, amount, date);
            pr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string sql = "DELETE FROM Expenses WHERE expense_id = @expense_id";


            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("expense_id", id);
            cmd.ExecuteNonQuery();
            loadProducts();
        }
    }
}
