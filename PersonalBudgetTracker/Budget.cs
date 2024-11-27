using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PersonalBudgetTracker
{
    public partial class Budget : UserControl
    {
        public string connectionString { get; set; }

        public Budget()
        {
            InitializeComponent();
            this.dataGridViewBudget.SelectionChanged += new System.EventHandler(this.dataGridViewBudget_SelectionChanged);

        }

        public void runBudget()
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
                    string query = "SELECT b.BudgetID, c.CategoryName, b.MonthlyLimit, c.CategoryType " +
                                   "FROM Budget b INNER JOIN Categories c ON b.CategoryID = c.CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);
                        dataGridViewBudget.DataSource = data;
                    }

                    // Hide the CategoryID column
                    if (dataGridViewBudget.Columns.Contains("BudgetID"))
                    {
                        dataGridViewBudget.Columns["BudgetID"].Visible = false;
                    }

                    // Load distinct category types into ComboBox
                    cbType.Items.Clear();
                    cbType.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbType.Items.Add("Income");
                    cbType.Items.Add("Expense");

                    // Calculate total income and expense
                    decimal totalIncome = 0;
                    decimal totalExpense = 0;

                    string totalQuery = "SELECT SUM(b.MonthlyLimit) AS TotalIncome FROM Budget b " +
                                        "INNER JOIN Categories c ON b.CategoryID = c.CategoryID " +
                                        "WHERE c.CategoryType = 'Income'";

                    using (SqlCommand totalCmd = new SqlCommand(totalQuery, connection))
                    {
                        object result = totalCmd.ExecuteScalar();
                        totalIncome = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    totalQuery = "SELECT SUM(b.MonthlyLimit) AS TotalExpense FROM Budget b " +
                                 "INNER JOIN Categories c ON b.CategoryID = c.CategoryID " +
                                 "WHERE c.CategoryType = 'Expense'";

                    using (SqlCommand totalCmd = new SqlCommand(totalQuery, connection))
                    {
                        object result = totalCmd.ExecuteScalar();
                        totalExpense = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    // Display totals in labels (make sure these labels exist in your form)
                    lblTotalIncome.Text = $"Budgeted Income: {totalIncome:C2}";
                    lblTotalExpense.Text = $"Budgeted Expense: {totalExpense:C2}";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }



        private void dataGridViewBudget_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dataGridViewBudget.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewBudget.SelectedRows[0];

                // Ensure that the selected row contains valid data
                if (selectedRow.Cells["CategoryName"].Value != null &&
                    selectedRow.Cells["CategoryType"].Value != null &&
                    selectedRow.Cells["MonthlyLimit"].Value != null)
                {
                    // Extract the values from the selected row
                    string categoryName = selectedRow.Cells["CategoryName"].Value.ToString();
                    string categoryType = selectedRow.Cells["CategoryType"].Value.ToString();
                    decimal monthlyLimit = Convert.ToDecimal(selectedRow.Cells["MonthlyLimit"].Value);

                    // Populate the controls with the selected values
                    txtCategory.Text = categoryName;
                    cbType.SelectedItem = categoryType; // Set the selected type in the ComboBox
                    txtBudgetLimit.Text = monthlyLimit.ToString("F2"); // Set the budget limit (formatted as a decimal)
                }
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type = cbType.Text;
            string category = txtCategory.Text;
            decimal budgetLimit;

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Category cannot be empty.");
                return;
            }

            if (!decimal.TryParse(txtBudgetLimit.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget limit.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insert the category if it doesn't exist
                    string categoryInsertQuery = "IF NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName = @Category) " +
                                                 "INSERT INTO Categories (CategoryName, CategoryType) VALUES (@Category, @Type)";
                    using (SqlCommand cmd = new SqlCommand(categoryInsertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into the Budget table
                    string insertQuery = "INSERT INTO Budget (CategoryID, MonthlyLimit) " +
                                         "VALUES ((SELECT CategoryID FROM Categories WHERE CategoryName = @Category), @BudgetLimit)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@BudgetLimit", budgetLimit);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Record added successfully!" : "Failed to add record.");
                        LoadAllData();
                    }

                    // Clear the fields after the insertion
                    cbType.SelectedIndex = -1; // Clear selected Type
                    txtCategory.Clear(); // Clear Category text box
                    txtBudgetLimit.Clear(); // Clear Budget Limit text box
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewBudget.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dataGridViewBudget.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["BudgetID"].Value);
            string type = cbType.Text;
            string category = txtCategory.Text;
            decimal budgetLimit;

            // Validate the input
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Category cannot be empty.");
                return;
            }

            if (!decimal.TryParse(txtBudgetLimit.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget limit.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the category exists and get the CategoryID
                    string categoryCheckQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = @Category";
                    int categoryId = 0;

                    using (SqlCommand cmd = new SqlCommand(categoryCheckQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // Category exists, get the CategoryID
                            categoryId = Convert.ToInt32(result);
                            // If the category exists, update its CategoryType if necessary
                            string updateCategoryTypeQuery = "UPDATE Categories SET CategoryType = @CategoryType WHERE CategoryID = @CategoryID";
                            using (SqlCommand updateCmd = new SqlCommand(updateCategoryTypeQuery, connection))
                            {
                                updateCmd.Parameters.AddWithValue("@CategoryType", type);
                                updateCmd.Parameters.AddWithValue("@CategoryID", categoryId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Category does not exist, insert into Categories table
                            string categoryInsertQuery = "INSERT INTO Categories (CategoryName, CategoryType) VALUES (@Category, @Type); " +
                                                         "SELECT SCOPE_IDENTITY();";
                            using (SqlCommand insertCmd = new SqlCommand(categoryInsertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@Category", category);
                                insertCmd.Parameters.AddWithValue("@Type", type);

                                // Get the inserted CategoryID
                                categoryId = Convert.ToInt32(insertCmd.ExecuteScalar());
                            }
                        }
                    }

                    // Update the Budget table with the new CategoryID and MonthlyLimit
                    string updateQuery = "UPDATE Budget SET CategoryID = @CategoryID, MonthlyLimit = @BudgetLimit WHERE BudgetID = @Id";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryId);
                        command.Parameters.AddWithValue("@BudgetLimit", budgetLimit);
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Record updated successfully!" : "Failed to update record.");
                        LoadAllData(); // Reload the data grid to reflect the update
                    }

                    // Clear the fields after updating the record
                    cbType.SelectedIndex = -1; // Clear selected Type
                    txtCategory.Clear(); // Clear Category text box
                    txtBudgetLimit.Clear(); // Clear Budget Limit text box

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }





        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBudget.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewBudget.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["BudgetID"].Value);

            string deleteQuery = "DELETE FROM Budget WHERE BudgetID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Record deleted successfully!" : "Failed to delete record.");
                        LoadAllData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
