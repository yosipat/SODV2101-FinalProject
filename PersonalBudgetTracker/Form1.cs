using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonalBudgetTracker
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent(); 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text; // Retrieve the value from txtName

            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            BaseForm baseform = new BaseForm(userName);
            baseform.Show();
            this.Hide();
        }
    }
}
