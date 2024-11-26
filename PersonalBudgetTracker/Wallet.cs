using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                    {
                        {
                            string query = "Select * from Wallet";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlDataReader reader = command.ExecuteReader();
                                DataTable data = new DataTable();
                                data.Load(reader);

                                dataGridView1.DataSource = data;
                                dataGridView1.Columns[0].Width = 50;
                            }
                        }

                        {
                            cbType.Items.Clear();
                            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
                            string query = "Select DISTINCT wType from Wallet";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlDataReader reader = command.ExecuteReader();
                                DataTable data = new DataTable();
                                data.Load(reader);

                                foreach (DataRow row in data.Rows)
                                {
                                    cbType.Items.Add(row["wType"]);
                                }
                                cbType.SelectedIndex = 0;
                            }
                        }

                        {
                            cbCategory.Items.Clear();
                            string query = "Select DISTINCT Category from Wallet";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlDataReader reader = command.ExecuteReader();
                                DataTable data = new DataTable();
                                data.Load(reader);

                                foreach (DataRow row in data.Rows)
                                {
                                    cbCategory.Items.Add(row["Category"]);
                                }
                                cbCategory.SelectedIndex = 0;
                            }
                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail :" + ex.ToString());
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
