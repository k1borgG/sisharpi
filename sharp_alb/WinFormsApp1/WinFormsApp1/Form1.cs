using Npgsql;
using System.Data;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection con;
        private string conString =
            "Host = 127.0.0.1; Username = postgres; Password = postpass; Database = abd";
        public Form1()
        {
            con = new NpgsqlConnection(conString);
            con.Open();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpensesAddForm ea = new ExpensesAddForm(con);
            ea.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpensesEmpView eev = new ExpensesEmpView(con);
            eev.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaxReportForm trf = new TaxReportForm(con);
            trf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PieChartForm pcf = new PieChartForm(con);
            pcf.ShowDialog();
        }




        private void button5_Click_1(object sender, EventArgs e)
        {
            EmployeeView employee = new EmployeeView(con);
            employee.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExpenseCategoriesView expensesCategories = new ExpenseCategoriesView(con);
            expensesCategories.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExpensesView expenses = new ExpensesView(con);
            expenses.ShowDialog();
        }
    }
}