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
        }

        public void runBudget()
        {
            InitializeMonths();
            LoadCategories();
            LoadBudgetData();
            LoadBalanceOverview();
        }

        private void LoadCategories()
        {
            cbCategory.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CategoryName FROM Categories WHERE CategoryType = 'Expense'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cbCategory.Items.Add(reader["CategoryName"].ToString());
                        }

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

        private void LoadBudgetData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            c.CategoryName AS [Category], 
                            b.MonthlyLimit AS [Budget], 
                            ISNULL(SUM(w.Amount), 0) AS [Expense], 
                            (b.MonthlyLimit - ISNULL(SUM(w.Amount), 0)) AS [Net],
                            FORMAT(w.TransactionDate, 'yyyy-MM') AS [Month]
                        FROM Budget b
                        JOIN Categories c ON b.CategoryID = c.CategoryID
                        LEFT JOIN Wallet w ON b.CategoryID = w.CategoryID 
                            AND MONTH(w.TransactionDate) = @Month
                        GROUP BY c.CategoryName, b.MonthlyLimit, FORMAT(w.TransactionDate, 'yyyy-MM')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int selectedMonth = comboBox1.SelectedIndex + 1;
                        command.Parameters.AddWithValue("@Month", selectedMonth);

                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);
                        dataGridView1.DataSource = data;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading budget data: " + ex.Message);
                }
            }
        }


        private void LoadBudgetSummary()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    ISNULL(SUM(b.MonthlyLimit), 0) AS TotalBudget,
                    ISNULL(SUM(w.Amount), 0) AS TotalExpense
                FROM Budget b
                LEFT JOIN Wallet w ON b.CategoryID = w.CategoryID";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        decimal totalBudget = reader.GetDecimal(0);
                        decimal totalExpense = reader.GetDecimal(1);
                        decimal remainingBudget = totalBudget - totalExpense;

                        lblTotalBudget.Text = $"Total Budget: ${totalBudget:F2}";
                        lblTotalExpense.Text = $"Total Expense: ${totalExpense:F2}";
                        lblControl.Text = $"Remaining Budget: ${remainingBudget:F2}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading budget summary: " + ex.Message);
                }
            }
        }

        private void LoadBalanceOverview()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        ISNULL(SUM(b.MonthlyLimit), 0) AS TotalBudget,
                        ISNULL(SUM(w.Amount), 0) AS TotalExpense
                    FROM Budget b
                    LEFT JOIN Wallet w ON b.CategoryID = w.CategoryID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            decimal totalBudget = Convert.ToDecimal(reader["TotalBudget"]);
                            decimal totalExpense = Convert.ToDecimal(reader["TotalExpense"]);
                            decimal remainingBudget = totalBudget - totalExpense;

                            lblTotalBudget.Text = $"Total Budget: ${totalBudget:F2}"; 
                            lblTotalExpense.Text = $"Total Expense: ${totalExpense:F2}";
                            lblRemainingBudget.Text = $"Remaining Budget: ${remainingBudget:F2}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading balance overview: " + ex.Message);
                }
            }
        }


        // Filter 
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                LoadBudgetData();
            }
            else
            {
                MessageBox.Show("Please select a month to filter data.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string category = cbCategory.Text; 
            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(textBox1.Text)) 
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            decimal budgetLimit;
            if (!decimal.TryParse(textBox1.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget amount.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Budget (CategoryID, MonthlyLimit) VALUES ((SELECT CategoryID FROM Categories WHERE CategoryName = @Category), @Limit)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Limit", budgetLimit);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Budget added successfully!");

                        LoadBalanceOverview();
                        LoadBudgetData();
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
            if (!decimal.TryParse(textBox1.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget amount.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Budget SET MonthlyLimit = @Limit WHERE CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = @Category)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Limit", budgetLimit);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Budget updated successfully!");

                        LoadBalanceOverview();
                        LoadBudgetData(); 
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
                    string query = "DELETE FROM Budget WHERE CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = @Category)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Budget deleted successfully!");
                        LoadBudgetData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting budget: " + ex.Message);
                }
            }
        }

        private void InitializeMonths()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("January");
            comboBox1.Items.Add("February");
            comboBox1.Items.Add("March");
            comboBox1.Items.Add("April");
            comboBox1.Items.Add("May");
            comboBox1.Items.Add("June");
            comboBox1.Items.Add("July");
            comboBox1.Items.Add("August");
            comboBox1.Items.Add("September");
            comboBox1.Items.Add("October");
            comboBox1.Items.Add("November");
            comboBox1.Items.Add("December");

            comboBox1.SelectedIndex = 0; 
        }
    }
}
