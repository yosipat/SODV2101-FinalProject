using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PersonalBudgetTracker
{
    public partial class Budget : UserControl
    {
        public string connectionString { get; set; }
        public Budget()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);

        }

        public void runBudget()
        {
            InitializeMonths();
            LoadCategories();
            LoadBudgetData();
            LoadBalanceOverview();
        }

        private void InitializeMonths()
        {
            cbFilterMonth.Items.Clear();
            cbFilterMonth.Items.Add("All");  // Add "All" option to the dropdown
            cbFilterMonth.Items.Add("January");
            cbFilterMonth.Items.Add("February");
            cbFilterMonth.Items.Add("March");
            cbFilterMonth.Items.Add("April");
            cbFilterMonth.Items.Add("May");
            cbFilterMonth.Items.Add("June");
            cbFilterMonth.Items.Add("July");
            cbFilterMonth.Items.Add("August");
            cbFilterMonth.Items.Add("September");
            cbFilterMonth.Items.Add("October");
            cbFilterMonth.Items.Add("November");
            cbFilterMonth.Items.Add("December");

            cbFilterMonth.SelectedIndex = 0;  // Default to "All"
        }

        private void LoadCategories()
        {
            // Clear existing items from the combo boxes
            cbCategory.Items.Clear();
            cbFilterCategory.Items.Clear();

            // Add "All" option to the filter category dropdown
            cbFilterCategory.Items.Add("All");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Load distinct category names from the Categories table
                    string query = "SELECT DISTINCT CategoryName FROM Categories";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string categoryName = reader["CategoryName"].ToString();
                            // Add category names to both combo boxes
                            cbCategory.Items.Add(categoryName);
                            cbFilterCategory.Items.Add(categoryName);
                        }

                        // Set default selection for cbFilterCategory to "All"
                        cbFilterCategory.SelectedIndex = 0;

                        // If categories were loaded, select the first item in cbCategory by default
                        if (cbCategory.Items.Count > 0)
                        {
                            cbCategory.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message);
                }
            }
        }


        private void LoadBudgetData(string selectedMonth = null, string selectedCategory = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
            SELECT 
                FORMAT(w.TransactionDate, 'MMM-yyyy') AS [Date],
                c.CategoryName AS [Category], 
                c.CategoryType AS [Type], 
                b.MonthlyLimit AS [Budget], 
                ISNULL(SUM(w.Amount), 0) AS [Wallet], 
                CASE 
                    WHEN c.CategoryType = 'Expense' THEN (b.MonthlyLimit - ISNULL(SUM(w.Amount), 0)) 
                    ELSE (ISNULL(SUM(w.Amount), 0) - b.MonthlyLimit) 
                END AS [Net] 
            FROM Categories c
            LEFT JOIN Budget b ON c.CategoryID = b.CategoryID
            LEFT JOIN Wallet w ON c.CategoryID = w.CategoryID";

                    // Apply month filter if selected
                    if (!string.IsNullOrEmpty(selectedMonth))
                    {
                        query += " WHERE MONTH(w.TransactionDate) = @Month";
                    }

                    // Apply category filter if selected
                    if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                    {
                        query += string.IsNullOrEmpty(selectedMonth) ? " WHERE" : " AND";
                        query += " c.CategoryName = @CategoryName";  // Filter by CategoryName now
                    }

                    query += @"
            GROUP BY 
                FORMAT(w.TransactionDate, 'MMM-yyyy'),
                c.CategoryName, 
                c.CategoryType, 
                b.MonthlyLimit
            ORDER BY [Date] DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for filters
                        if (!string.IsNullOrEmpty(selectedMonth))
                        {
                            int monthNumber = DateTime.ParseExact(selectedMonth, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;
                            command.Parameters.AddWithValue("@Month", monthNumber);
                        }
                        if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                        {
                            command.Parameters.AddWithValue("@CategoryName", selectedCategory);  // Updated parameter for category name
                        }

                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);
                        dataGridView1.DataSource = data;

                        // Hide the Type column
                        dataGridView1.Columns["Type"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading budget data: " + ex.Message);
                }
            }
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Get the selected category from the DataGridView
                string selectedCategory = selectedRow.Cells["Category"].Value.ToString();
                object budgetValue = selectedRow.Cells["Budget"].Value;

                // Check if the budget value is DBNull before converting
                decimal selectedBudgetLimit = budgetValue != DBNull.Value ? Convert.ToDecimal(budgetValue) : 0;

                // Set the selected category in the combo box
                cbCategory.SelectedItem = selectedCategory;

                // Set the selected budget limit in the text box
                txtBudgetLimit.Text = selectedBudgetLimit.ToString("F2"); // Format as currency or with 2 decimals
            }
        }


        private void LoadBalanceOverview()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Updated query to sum the remaining balances
                    string query = @"
            SELECT SUM(
                    CASE 
                        WHEN c.CategoryType = 'Income' THEN (w.Amount - b.MonthlyLimit)
                        WHEN c.CategoryType = 'Expense' THEN (b.MonthlyLimit - w.Amount)
                        ELSE 0
                    END
                ) AS TotalRemainingBalance
            FROM Wallet w
            JOIN Categories c ON w.CategoryID = c.CategoryID
            JOIN Budget b ON c.CategoryID = b.CategoryID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        decimal totalRemainingBalance = 0m;

                        while (reader.Read())
                        {
                            // Sum up the remaining balance from the query result
                            if (reader["TotalRemainingBalance"] != DBNull.Value)
                            {
                                totalRemainingBalance += Convert.ToDecimal(reader["TotalRemainingBalance"]);
                            }
                        }

                        // Check if the remaining balance is positive or negative
                        if (totalRemainingBalance > 0)
                        {
                            lblRemainingBudget.Text = $"Saved: ${totalRemainingBalance:F2}";
                        }
                        else if (totalRemainingBalance < 0)
                        {
                            lblRemainingBudget.Text = $"Overspent: ${Math.Abs(totalRemainingBalance):F2}";
                        }
                        else
                        {
                            lblRemainingBudget.Text = "No Balance";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading balance overview: " + ex.Message);
                }
            }
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedMonth = cbFilterMonth.SelectedItem.ToString();
            string selectedCategoryType = cbFilterCategory.SelectedItem.ToString();

            if (selectedMonth == "All")
            {
                // Load data without month filtering if "All" is selected
                LoadBudgetData(null, selectedCategoryType);  // Pass selectedCategoryType
            }
            else if (!string.IsNullOrEmpty(selectedMonth))
            {
                // Filter data by the selected month and category
                LoadBudgetData(selectedMonth, selectedCategoryType);  // Pass both filters
            }
            else
            {
                MessageBox.Show("Please select a month to filter data.");
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string category = cbCategory.Text;
            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(txtBudgetLimit.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            decimal budgetLimit;
            if (!decimal.TryParse(txtBudgetLimit.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget amount.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Check if category exists
                    string categoryQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = @Category";
                    using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                    {
                        categoryCommand.Parameters.AddWithValue("@Category", category);
                        object result = categoryCommand.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Category does not exist.");
                            return;
                        }

                        int categoryId = Convert.ToInt32(result);
                        string query = "INSERT INTO Budget (CategoryID, MonthlyLimit) VALUES (@CategoryID, @Limit)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryID", categoryId);
                            command.Parameters.AddWithValue("@Limit", budgetLimit);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Budget added successfully!");

                            // Reload data
                            LoadBalanceOverview();
                            LoadBudgetData();

                            // Clear the fields after adding
                            cbCategory.SelectedIndex = -1; // Clears the selected category
                            txtBudgetLimit.Clear(); // Clears the text box for the budget limit
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding budget: " + ex.Message);
                }
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string category = selectedRow.Cells["Category"].Value.ToString();

            decimal budgetLimit;
            if (!decimal.TryParse(txtBudgetLimit.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget amount.");
                return;
            }

            // Ensure that the budget limit is a valid number and positive
            if (budgetLimit <= 0)
            {
                MessageBox.Show("Budget limit must be a positive number.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if category exists in the Categories table
                    string categoryQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = @Category";
                    using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                    {
                        categoryCommand.Parameters.AddWithValue("@Category", category);
                        object result = categoryCommand.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Category does not exist.");
                            return;
                        }

                        int categoryId = Convert.ToInt32(result);

                        // Check if the category has an existing budget entry
                        string checkBudgetQuery = "SELECT COUNT(*) FROM Budget WHERE CategoryID = @CategoryID";
                        using (SqlCommand checkBudgetCommand = new SqlCommand(checkBudgetQuery, connection))
                        {
                            checkBudgetCommand.Parameters.AddWithValue("@CategoryID", categoryId);
                            int count = Convert.ToInt32(checkBudgetCommand.ExecuteScalar());

                            if (count == 0)
                            {
                                MessageBox.Show("No budget found for this category.");
                                return;
                            }
                        }

                        // Update the budget for the selected category
                        string query = "UPDATE Budget SET MonthlyLimit = @Limit WHERE CategoryID = @CategoryID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryID", categoryId);
                            command.Parameters.AddWithValue("@Limit", budgetLimit);
                            command.ExecuteNonQuery();

                            MessageBox.Show("Budget updated successfully!");

                            // Reload the data
                            LoadBalanceOverview();
                            LoadBudgetData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating budget: " + ex.Message);
                }
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string category = selectedRow.Cells["Category"].Value.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string categoryQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = @Category";
                    using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                    {
                        categoryCommand.Parameters.AddWithValue("@Category", category);
                        object result = categoryCommand.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Category does not exist.");
                            return;
                        }

                        int categoryId = Convert.ToInt32(result);
                        // Check if the category is linked to any records in the Budget table
                        string checkBudgetQuery = "SELECT COUNT(*) FROM Budget WHERE CategoryID = @CategoryID";
                        using (SqlCommand checkBudgetCommand = new SqlCommand(checkBudgetQuery, connection))
                        {
                            checkBudgetCommand.Parameters.AddWithValue("@CategoryID", categoryId);
                            int count = Convert.ToInt32(checkBudgetCommand.ExecuteScalar());

                            if (count == 0)
                            {
                                MessageBox.Show("Category does not have an associated budget, and cannot be deleted.");
                                return;
                            }
                        }

                        string query = "DELETE FROM Budget WHERE CategoryID = @CategoryID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryID", categoryId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Budget deleted successfully!");

                            LoadBudgetData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting budget: " + ex.Message);
                }
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            // Ask the user to select a location and filename for the CSV file, defaulting to "BudgetData.csv"
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Budget Data as CSV";
            saveFileDialog.FileName = "BudgetData.csv";  // Default file name
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder csvContent = new StringBuilder();

                    // Add column headers
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        csvContent.Append(column.HeaderText + ",");
                    }
                    csvContent.Length--;  // Remove the last comma
                    csvContent.AppendLine();  // Move to the next line

                    // Add rows of data
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            // Handle possible null values
                            if (cell.Value != null)
                            {
                                csvContent.Append(cell.Value.ToString().Replace(",", ";") + ",");
                            }
                            else
                            {
                                csvContent.Append(","); // Empty cell
                            }
                        }
                        csvContent.Length--;  // Remove the last comma
                        csvContent.AppendLine();  // Move to the next line
                    }

                    // Save the CSV file
                    System.IO.File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                    MessageBox.Show("Data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
