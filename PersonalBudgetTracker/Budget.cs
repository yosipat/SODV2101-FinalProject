

using Microsoft.Data.SqlClient;
using System.Data;

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
                    string query = "SELECT * FROM Budget";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);
                        dataGridViewBudget.DataSource = data;
                    }

                    // Load predefined types into ComboBox
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type = cbType.Text;
            string category = txtCategory.Text;
            decimal budgetLimit;
            string month = txtMonth.Text;

            if (!decimal.TryParse(txtBudgetLimit.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget limit.");
                return;
            }

            string query = "INSERT INTO Budget (Type, Category, BudgetLimit, Month) VALUES (@Type, @Category, @BudgetLimit, @Month)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@BudgetLimit", budgetLimit);
                        command.Parameters.AddWithValue("@Month", month);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Record added successfully!" : "Failed to add record.");
                        LoadAllData();
                    }
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
            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string type = cbType.Text;
            string category = txtCategory.Text;
            decimal budgetLimit;
            string month = txtMonth.Text;

            if (!decimal.TryParse(txtBudgetLimit.Text, out budgetLimit))
            {
                MessageBox.Show("Invalid budget limit.");
                return;
            }

            string query = "UPDATE Budget SET Type = @Type, Category = @Category, BudgetLimit = @BudgetLimit, Month = @Month WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@BudgetLimit", budgetLimit);
                        command.Parameters.AddWithValue("@Month", month);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Record updated successfully!" : "Failed to update record.");
                        LoadAllData();
                    }
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
            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            string query = "DELETE FROM Budget WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
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
