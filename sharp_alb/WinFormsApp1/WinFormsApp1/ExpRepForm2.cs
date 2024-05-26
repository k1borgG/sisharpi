using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ExpRepForm2 : Form
    {
        public NpgsqlConnection conn;
        public ExpensesEmpView form1;
        public bool isNewMode = false;
        public int CurrentEmployeeID;
        public int ReportingExpensesID;

        private int oldQuantityValue;

        public ExpRepForm2(ExpensesEmpView f, NpgsqlConnection con)
        {
            InitializeComponent();
            form1 = f;
            conn = con;
            numericUpDown1.Value = 1;
        }

        private void invoiceAddForm_Load(object sender, EventArgs e)
        {
            LoadCustomerNames();
        }

        private void ConfigureDataGridView()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText != "Количество")
                {
                    column.ReadOnly = true;
                }
            }

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CellValidating += DataGridView1_CellValidating;
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
        }


        public void LoadCustomerNames()
        {
            DataTable dtCategories = new DataTable();
            string sqlCategories = "SELECT category_id, category_name FROM ExpenseCategories;";
            using (NpgsqlDataAdapter adapCategories = new NpgsqlDataAdapter(sqlCategories, conn))
            {
                adapCategories.Fill(dtCategories);
            }
            comboBox1.DataSource = dtCategories;
            comboBox1.DisplayMember = "category_name";
            comboBox1.ValueMember = "category_id";

            if (ReportingExpensesID != 0)
            {
                DataTable dt = new DataTable();
                string sql = @"
                SELECT 
                    ec.category_name, 
                    ecm.quantity, 
                    (ec.category_cost * ecm.quantity) AS total_cost
                FROM 
                    Expenses e 
                JOIN 
                    ExpenseCategoryMappings ecm ON e.expense_id = ecm.expense_id
                JOIN 
                    ExpenseCategories ec ON ecm.category_id = ec.category_id
                WHERE 
                    e.expense_id = @expense_id;";

                using (NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sql, conn))
                {
                    adap.SelectCommand.Parameters.AddWithValue("@expense_id", ReportingExpensesID);
                    adap.Fill(dt);
                }

                dataGridView1.DataSource = dt;

                decimal totalSelectedCost = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalSelectedCost += Convert.ToDecimal(row["total_cost"]);
                }
                label3.Text = $"{totalSelectedCost}";

                dataGridView1.Columns[0].HeaderText = "Статья расходов";
                dataGridView1.Columns[1].HeaderText = "Количество";
                dataGridView1.Columns[2].HeaderText = "Общая сумма";

                ConfigureDataGridView();

                string amountSql = "SELECT amount FROM Expenses WHERE expense_id = @expense_id;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(amountSql, conn))
                {
                    cmd.Parameters.AddWithValue("@expense_id", ReportingExpensesID);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        decimal amount = Convert.ToDecimal(result);
                        label3.Text = $"{amount}";
                    }
                    else
                    {
                        label3.Text = "0!";
                    }
                }

            }
        }

        public void SetExpense(int id)
        {
            ReportingExpensesID = id;
            if (ReportingExpensesID == 0)
            {
                label3.Text = "0";
            }
        }
        public void SetMode(int id)
        {
            CurrentEmployeeID = id;
            isNewMode = true;
            label3.Text = "0";
        }

        private void CreateNewExpense()
        {
            string insertSql = "INSERT INTO Expenses (employee_id, amount, date, reported) VALUES (@employee_id, @amount, @date, @reported) RETURNING expense_id";
            string insertTaxSql = "INSERT INTO Taxes (expense_id, tax_amount) VALUES (@expense_id, @tax_amount)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("@employee_id", CurrentEmployeeID);
                cmd.Parameters.AddWithValue("@amount", 0);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@reported", true);
                ReportingExpensesID = (int)cmd.ExecuteScalar();
                LoadCustomerNames();
            }

            using (NpgsqlCommand cmd = new NpgsqlCommand(insertTaxSql, conn))
            {
                cmd.Parameters.AddWithValue("@expense_id", ReportingExpensesID);
                cmd.Parameters.AddWithValue("@tax_amount", 0);  
                cmd.ExecuteNonQuery();
            }

        }

        private void UpdateExpenseAmount(int expenseId, decimal newTotalCost)
        {
            string updateSql = "UPDATE Expenses SET amount = @amount WHERE expense_id = @expense_id";
            using (NpgsqlCommand cmd = new NpgsqlCommand(updateSql, conn))
            {
                cmd.Parameters.AddWithValue("@amount", newTotalCost);
                cmd.Parameters.AddWithValue("@expense_id", expenseId);
                cmd.ExecuteNonQuery();
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isNewMode)
            {
                CreateNewExpense();
                isNewMode = false;
                LoadCustomerNames();
            }
            
                if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int categoryId))
                {
                    int quantity = (int)numericUpDown1.Value;
                    int expenseId = ReportingExpensesID;

                    AddExpenseCategoryMapping(expenseId, categoryId, quantity);
                    numericUpDown1.Value = 1;
                    LoadCustomerNames();
                }

            LoadCustomerNames();
        }



        public void AddExpenseCategoryMapping(int expenseId, int categoryId, int quantity)
        {
            decimal currentTotalCost = Convert.ToDecimal(label3.Text);

            string getCategoryCostSql = "SELECT category_cost FROM ExpenseCategories WHERE category_id = @category_id";
            decimal categoryCost;
            using (NpgsqlCommand getCategoryCostCmd = new NpgsqlCommand(getCategoryCostSql, conn))
            {
                getCategoryCostCmd.Parameters.AddWithValue("@category_id", categoryId);
                categoryCost = Convert.ToDecimal(getCategoryCostCmd.ExecuteScalar());
            }

            string checkSql = "SELECT quantity FROM ExpenseCategoryMappings WHERE expense_id = @expense_id AND category_id = @category_id";
            using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, conn))
            {
                checkCmd.Parameters.AddWithValue("@expense_id", expenseId);
                checkCmd.Parameters.AddWithValue("@category_id", categoryId);
                object result = checkCmd.ExecuteScalar();

                decimal newTotalCost = currentTotalCost + (quantity * categoryCost);

                if (result != null)
                {
                    int currentQuantity = Convert.ToInt32(result);
                    int newQuantity = currentQuantity + quantity;
                    string updateSql = "UPDATE ExpenseCategoryMappings SET quantity = @quantity WHERE expense_id = @expense_id AND category_id = @category_id";
                    using (NpgsqlCommand updateCmd = new NpgsqlCommand(updateSql, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@quantity", newQuantity);
                        updateCmd.Parameters.AddWithValue("@expense_id", expenseId);
                        updateCmd.Parameters.AddWithValue("@category_id", categoryId);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertSql = "INSERT INTO ExpenseCategoryMappings (expense_id, category_id, quantity) VALUES (@expense_id, @category_id, @quantity)";
                    using (NpgsqlCommand insertCmd = new NpgsqlCommand(insertSql, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@expense_id", expenseId);
                        insertCmd.Parameters.AddWithValue("@category_id", categoryId);
                        insertCmd.Parameters.AddWithValue("@quantity", quantity);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                UpdateExpenseAmount(expenseId, newTotalCost);
                label3.Text = $"{newTotalCost}";
            }
        }

        
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[1] != null)
            {
                int quantityColumnIndex = dataGridView1.Columns[1].Index;
                if (e.ColumnIndex == quantityColumnIndex && e.RowIndex >= 0)
                {
                    int expenseId = ReportingExpensesID;
                    int categoryId = GetCategoryIdFromRow(e.RowIndex);
                    int quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quantityColumnIndex].Value);

                    if (quantity == 0)
                    {
                        DeleteExpenseCategoryMapping(expenseId, categoryId);
                    }
                    else
                    {
                        UpdateExpenseCategoryMapping(expenseId, categoryId, quantity);
                    }

                    LoadCustomerNames();
                }
            }
        }

        private int GetCategoryIdFromRow(int rowIndex)
        {
            if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows[rowIndex].Cells[0].Value == null)
            {
                return 0;
            }

            string categoryName = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            string query = "SELECT category_id FROM ExpenseCategories WHERE category_name = @category_name";
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@category_name", categoryName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void DeleteExpenseCategoryMapping(int expenseId, int categoryId)
        {
            string sql = "DELETE FROM ExpenseCategoryMappings WHERE expense_id = @expense_id AND category_id = @category_id";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@expense_id", expenseId);
                cmd.Parameters.AddWithValue("@category_id", categoryId);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateExpenseCategoryMapping(int expenseId, int categoryId, int quantity)
        {
            string sql = "UPDATE ExpenseCategoryMappings SET quantity = @quantity WHERE expense_id = @expense_id AND category_id = @category_id";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@expense_id", expenseId);
                cmd.Parameters.AddWithValue("@category_id", categoryId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.ExecuteNonQuery();
            }
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[1] != null)
            {
                int quantityColumnIndex = dataGridView1.Columns[1].Index;
                if (e.ColumnIndex == quantityColumnIndex)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int newValue) || newValue < 0)
                    {
                        e.Cancel = true;
                        dataGridView1.CancelEdit();
                        return;
                    }

                }
            }
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Columns[1] != null && e.ColumnIndex == dataGridView1.Columns[1].Index)
            {
                oldQuantityValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value != DBNull.Value
                    ? Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value)
                    : 0;
            }
        }
    }
}
