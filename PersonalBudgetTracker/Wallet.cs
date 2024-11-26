using Microsoft.Data.SqlClient;
using System.Data;

namespace PersonalBudgetTracker
{
    public partial class Wallet : UserControl
    {
        public string connectionString { get; set; }
        public Wallet()
        {
            InitializeComponent();
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
                    string query = "SELECT * FROM Wallet";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);

                        dataGridView1.DataSource = data;
                        dataGridView1.Columns[0].Width = 50;
                    }

                    // Load predefined transaction types into cbType
                    cbType.Items.Clear();
                    cbType.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbType.Items.Add("Income");
                    cbType.Items.Add("Expense");
                    // No default selection here.

                    // Load distinct categories into cbCategory
                    cbCategory.Items.Clear();
                    string categoryQuery = "SELECT DISTINCT Category FROM Wallet";
                    using (SqlCommand command = new SqlCommand(categoryQuery, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cbCategory.Items.Add(reader["Category"].ToString());
                        }
                        // Do not set SelectedIndex to 0.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail: " + ex.Message);
                }
            }
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string type = selectedRow.Cells["wType"].Value.ToString(); //get value from column "UserName"
                string category = selectedRow.Cells["Category"].Value.ToString(); //get value from column "Email"
                string amount = selectedRow.Cells["Amount"].Value.ToString();
                string date = selectedRow.Cells["wDate"].Value.ToString();


                cbType.SelectedItem = type;
                cbCategory.SelectedItem = category;
                dtDate.Value = DateTime.Parse(date);
                txtAmount.Text = amount;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string category = cbCategory.Text;
            string type = cbType.SelectedItem.ToString();
            double amount = Convert.ToDouble(txtAmount.Text);
            DateTime date = dtDate.Value;

            ErrorProvider errorProvider = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(category))
            {
                errorProvider.SetError(cbCategory, "Category must be not empty");
                return;
            }

            string insertQuery = "INSERT INTO Wallet VALUES(@category,@amount,@type,@date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@category", category);
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@date", date);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Transaction added successfully!" : "Failed to add transaction");
                        LoadAllData();

                        txtAmount.Text = "";

                        errorProvider.SetError(cbCategory, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail :" + ex.ToString());
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
            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            string category = cbCategory.Text;
            string type = cbType.SelectedItem.ToString();
            double amount = Convert.ToDouble(txtAmount.Text);
            DateTime date = dtDate.Value;

            string updateQuery = "UPDATE Wallet SET Category=@category, Amount=@amount, wType=@type, wDate=@date WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@category", category);
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Transaction updated successfully!" : "Failed to update transaction");
                        LoadAllData();
                        txtAmount.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail :" + ex.ToString());
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
            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            string deleteQuery = "DELETE FROM Wallet WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Transaction deleted successfully!" : "Failed to delete transaction");

                        LoadAllData();
                        txtAmount.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail :" + ex.ToString());
                }
            }

        }
    }
}
