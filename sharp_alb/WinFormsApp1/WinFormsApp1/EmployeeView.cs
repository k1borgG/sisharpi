using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EmployeeView : Form
    {
        private NpgsqlConnection con;

        public EmployeeView(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        public void LoadEmployees()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM Employees", con);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Имя работника";

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
        }

        private void employeeView_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit ca = new EmployeeAddEdit(this, con);
            ca.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit ca = new EmployeeAddEdit(this, con);

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            ca.SetEditData(id, name);
            ca.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string sql = "DELETE FROM Employees WHERE employee_id = @employee_id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("employee_id", id);
            cmd.ExecuteNonQuery();
            LoadEmployees();
        }
    }
}