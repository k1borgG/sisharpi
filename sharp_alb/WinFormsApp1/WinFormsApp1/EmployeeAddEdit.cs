using Npgsql;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EmployeeAddEdit : Form
    {
        public NpgsqlConnection conn;
        public EmployeeView form1;
        public bool IsEditMode = false;
        public int EditingEmployeeId;

        public EmployeeAddEdit(EmployeeView f, NpgsqlConnection con)
        {
            InitializeComponent();
            form1 = f;
            conn = con;
        }

        public void SetEditData(int employeeId, string name)
        {
            textBox1.Text = name;

            EditingEmployeeId = employeeId;
            IsEditMode = true;
            button1.Text = "Изменить";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
                sql = @"UPDATE employees SET name=@name
                        WHERE employee_id=@employee_id";
            }
            else
            {
                sql = @"INSERT INTO employees(name) 
                        VALUES (@name)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);



            if (IsEditMode)
            {
                cmd.Parameters.AddWithValue("@employee_id", EditingEmployeeId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            form1.LoadEmployees();

            if (!IsEditMode)
            {
                textBox1.Text = "";
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
    }
}