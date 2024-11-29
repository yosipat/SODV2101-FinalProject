using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PersonalBudgetTracker
{
    public partial class Category : UserControl
    {
        public string connectionString { get; set; }

        public Category()
        {
            InitializeComponent();
            this.dataGridViewBudget.SelectionChanged += new System.EventHandler(this.dataGridViewBudget_SelectionChanged);
        }

        public void runCategory()
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
                    string query = "SELECT CategoryID, CategoryName, CategoryType FROM Categories";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);

                        // Refresh the DataGridView data source
                        dataGridViewBudget.DataSource = null;
                        dataGridViewBudget.DataSource = data;
                    }

                    // Hide the CategoryID column
                    if (dataGridViewBudget.Columns.Contains("CategoryID"))
                    {
                        dataGridViewBudget.Columns["CategoryID"].Visible = false;
                    }

                    // Load distinct category types into ComboBox
                    cbType.Items.Clear();
                    cbType.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbType.Items.Add("Income");
                    cbType.Items.Add("Expense");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void dataGridViewBudget_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBudget.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewBudget.SelectedRows[0];
                if (selectedRow.Cells["CategoryName"].Value != null &&
                    selectedRow.Cells["CategoryType"].Value != null)
                {
                    txtCategory.Text = selectedRow.Cells["CategoryName"].Value.ToString();
                    cbType.SelectedItem = selectedRow.Cells["CategoryType"].Value.ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type = cbType.Text;
            string category = txtCategory.Text;

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Category cannot be empty.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string categoryInsertQuery = "IF NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName = @Category) " +
                                                 "INSERT INTO Categories (CategoryName, CategoryType) VALUES (@Category, @Type)";
                    using (SqlCommand cmd = new SqlCommand(categoryInsertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.ExecuteNonQuery();
                    }

                    LoadAllData();
                    cbType.SelectedIndex = -1;
                    txtCategory.Clear();
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

            DataGridViewRow selectedRow = dataGridViewBudget.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);
            string type = cbType.Text;
            string category = txtCategory.Text;

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Category cannot be empty.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE Categories SET CategoryName = @CategoryName, CategoryType = @CategoryType " +
                                         "WHERE CategoryID = @CategoryID";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", category);
                        command.Parameters.AddWithValue("@CategoryType", type);
                        command.Parameters.AddWithValue("@CategoryID", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Record updated successfully!" : "Failed to update record.");
                    }

                    LoadAllData();
                    cbType.SelectedIndex = -1;
                    txtCategory.Clear();
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
            int id = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);

            string deleteQuery = "DELETE FROM Categories WHERE CategoryID = @CategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Record deleted successfully!" : "Failed to delete record.");
                    }

                    LoadAllData();
                    cbType.SelectedIndex = -1;
                    txtCategory.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
