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
    public partial class ExpensesEmpView : Form
    {

        private NpgsqlConnection con;
        public ExpensesEmpView(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        public void LoadProducts()
        {

            DataTable dt2 = new DataTable();
            NpgsqlDataAdapter adap2 = new NpgsqlDataAdapter("SELECT employee_id, name FROM Employees", con);
            adap2.Fill(dt2);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "employee_id";


            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            LoadDataGrid();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            if (comboBox1.SelectedValue != null)
            {

                int selectedEmployeeId;
                if (int.TryParse(comboBox1.SelectedValue.ToString(), out selectedEmployeeId))
                {
                    DataTable dt = new DataTable();
                    using (NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT expense_id, amount, date FROM Expenses WHERE employee_id = @employee_id AND reported = FALSE", con))
                    {
                        adap.SelectCommand.Parameters.AddWithValue("@employee_id", selectedEmployeeId);
                        adap.Fill(dt);
                    }
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Сумма";
                    dataGridView1.Columns[1].HeaderText = "Дата";
                }
            }
        }


        private void productView_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpRepForm erf = new ExpRepForm(this, con);
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            erf.SetExpense(id);
            erf.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExpRepForm2 erf = new ExpRepForm2(this, con);
            int id = Convert.ToInt32(comboBox1.SelectedValue);
            erf.SetMode(id);
            erf.ShowDialog();
        }
    }
}
