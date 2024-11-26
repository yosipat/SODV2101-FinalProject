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
            BaseForm baseform = new BaseForm();
            baseform.Show();
            this.Hide();
        }
    }
}
