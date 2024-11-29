using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PersonalBudgetTracker
{
    public partial class Wallet : UserControl
    {
        public string connectionString { get; set; }


        public Wallet()
        {
            InitializeComponent();

            // Attach event handlers
            cbType.SelectedIndexChanged += cbType_SelectedIndexChanged;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
        }

        public void runWallet()
        {
            LoadAllData();
        }

        public void LoadAllData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Load data into DataGridView
                    string query = "SELECT Wallet.TransactionID, Wallet.Amount, Categories.CategoryName, Wallet.TransactionDate " +
                                   "FROM Wallet " +
                                   "INNER JOIN Categories ON Wallet.CategoryID = Categories.CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);
                        dataGridView1.DataSource = data;
                        dataGridView1.Columns[0].Width = 50;  // Set the width for the first column (TransactionID)

                        // Hide the TransactionID column
                        dataGridView1.Columns["TransactionID"].Visible = false;
                    }

                    // Load categories and types from the database
                    LoadCategoryTypesAndCategories();

                    // Clear fields after loading data
                    cbType.SelectedIndex = -1;  // Clear the Type ComboBox
                    cbCategory.SelectedIndex = -1;  // Clear the Category ComboBox
                    txtAmount.Clear();  // Clear the Amount text box
                    dtDate.Value = DateTime.Now;  // Reset the Date Picker to current date

                    // Update the balance
                    UpdateBalance();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UpdateBalance()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to calculate total income and expense
                    string incomeQuery = "SELECT SUM(Amount) FROM Wallet INNER JOIN Categories ON Wallet.CategoryID = Categories.CategoryID WHERE Categories.CategoryType = 'Income'";
                    string expenseQuery = "SELECT SUM(Amount) FROM Wallet INNER JOIN Categories ON Wallet.CategoryID = Categories.CategoryID WHERE Categories.CategoryType = 'Expense'";

                    // Execute the income query
                    object incomeResult = new SqlCommand(incomeQuery, connection).ExecuteScalar();
                    double totalIncome = (incomeResult == DBNull.Value) ? 0 : Convert.ToDouble(incomeResult);

                    // Execute the expense query
                    object expenseResult = new SqlCommand(expenseQuery, connection).ExecuteScalar();
                    double totalExpense = (expenseResult == DBNull.Value) ? 0 : Convert.ToDouble(expenseResult);

                    // Calculate balance (Income - Expense)
                    double balance = totalIncome - totalExpense;

                    // Update the balance label
                    lblBalance.Text = $"Balance: ${balance:F2}"; // Format the balance to 2 decimal places
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




        // Method to load categories and types based on the database values
        private void LoadCategoryTypesAndCategories()
        {
            cbType.Items.Clear();
            cbCategory.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Load distinct CategoryTypes
                    string typeQuery = "SELECT DISTINCT CategoryType FROM Categories";
                    using (SqlCommand command = new SqlCommand(typeQuery, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cbType.Items.Add(reader["CategoryType"].ToString());
                        }

                        if (cbType.Items.Count > 0)
                        {
                            cbType.SelectedIndex = 0; // Set default selection to first type (e.g., Income)
                        }
                    }

                    // Load categories for the default type (Income)
                    LoadCategories(cbType.SelectedItem?.ToString() ?? "Income");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Method to load categories based on selected type
        private void LoadCategories(string categoryType)
        {
            cbCategory.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CategoryName FROM Categories WHERE CategoryType = @CategoryType";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryType", categoryType);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cbCategory.Items.Add(reader["CategoryName"].ToString());
                        }

                        if (cbCategory.Items.Count > 0)
                        {
                            cbCategory.SelectedIndex = 0; // Default select the first category
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Event handler when the user selects a Type (Income/Expense)
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cbType.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedType))
            {
                LoadCategories(selectedType); // Load corresponding categories for selected type
            }
        }

        // Event handler when the user selects a Category
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbCategory.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedCategory))
            {
                // Update category type based on selected category
                cbType.SelectedItem = GetCategoryTypeByName(selectedCategory);
            }
        }

        // Get CategoryType by Category name
        private string GetCategoryTypeByName(string categoryName)
        {
            string categoryType = string.Empty;
            string query = "SELECT CategoryType FROM Categories WHERE CategoryName = @categoryName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@categoryName", categoryName);
                        object result = command.ExecuteScalar();
                        categoryType = result?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return categoryType;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string category = selectedRow.Cells["CategoryName"].Value.ToString();
                string amount = selectedRow.Cells["Amount"].Value.ToString();
                string date = selectedRow.Cells["TransactionDate"].Value.ToString();

                cbCategory.SelectedItem = category;
                cbType.SelectedItem = GetCategoryTypeByName(category); // Sync Category Type with Category
                dtDate.Value = DateTime.Parse(date);
                txtAmount.Text = amount;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string category = cbCategory.Text;
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Category must not be empty!");
                return;
            }

            double amount = Convert.ToDouble(txtAmount.Text);
            DateTime date = dtDate.Value;
            int categoryId = GetCategoryIdByName(category);

            string insertQuery = "INSERT INTO Wallet (Amount, CategoryID, TransactionDate) " +
                                 "VALUES (@amount, @categoryId, @date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@categoryId", categoryId);
                        command.Parameters.AddWithValue("@date", date);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Transaction added successfully!" : "Failed to add transaction");
                        LoadAllData();

                        // Clear the fields after adding the transaction
                        cbType.SelectedIndex = -1;  // Clear the Type ComboBox
                        cbCategory.SelectedIndex = -1;  // Clear the Category ComboBox
                        txtAmount.Clear();  // Clear the Amount text box
                        dtDate.Value = DateTime.Now;  // Reset the Date Picker to current date
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update!");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["TransactionID"].Value);

            string category = cbCategory.Text;
            double amount = Convert.ToDouble(txtAmount.Text);
            DateTime date = dtDate.Value;
            int categoryId = GetCategoryIdByName(category);

            string updateQuery = "UPDATE Wallet SET Amount=@amount, CategoryID=@categoryId, TransactionDate=@date WHERE TransactionID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@categoryId", categoryId);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Transaction updated successfully!" : "Failed to update transaction");
                        LoadAllData();
                        txtAmount.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["TransactionID"].Value);

            string deleteQuery = "DELETE FROM Wallet WHERE TransactionID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Transaction deleted successfully!" : "Failed to delete transaction");

                        LoadAllData();
                        txtAmount.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
        }

        private void ExportDataGridViewToCSV(DataGridView dgv)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.FileName = "WalletData.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            if (column.Visible)
                            {
                                sb.Append(column.HeaderText + ",");
                            }
                        }
                        sb.AppendLine();

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Visible)
                                {
                                    sb.Append(cell.Value?.ToString().Replace(",", ";") + ",");
                                }
                            }
                            sb.AppendLine();
                        }

                        writer.Write(sb.ToString());
                    }

                    MessageBox.Show("Data exported successfully to CSV!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data: " + ex.Message);
                }
            }
        }

        // Helper method to get CategoryID from Category name
        private int GetCategoryIdByName(string categoryName)
        {
            int categoryId = 0;

            string categoryQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = @categoryName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(categoryQuery, connection))
                    {
                        command.Parameters.AddWithValue("@categoryName", categoryName);
                        categoryId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return categoryId;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToCSV(dataGridView1);
        }


    }
}
