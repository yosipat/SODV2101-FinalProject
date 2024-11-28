using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalBudgetTracker
{
    public partial class BaseForm : Form
    {

        //public string connectionString = "Data Source=STEPH-LAPTOP\\SQLEXPRESS; Initial Catalog= BudgetTracker; Integrated Security=True; TrustServerCertificate=true";
        public string connectionString = "Data Source=STEPH-LAPTOP\\SQLEXPRESS; Initial Catalog= BudgetTracker; Integrated Security=True; TrustServerCertificate=true";
        public BaseForm()
        {

            InitializeComponent();

            homePage.Visible = true;
            walletPage.Visible = false;
            CategoryPage.Visible = false;
            budgetPage.Visible = false;

            homePage.connectionString = connectionString;
            homePage.runHomePage();

            // Add navigation event handlers to buttons
            btnHome.Click += btnHome_Click;
            btnCategory.Click += btnCategory_Click;
            btnWallet.Click += btnWallet_Click;
            btnBudget.Click += btnBudget_Click;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homePage.connectionString = connectionString;
            homePage.runHomePage();

            homePage.Visible = true;
            walletPage.Visible = false;
            CategoryPage.Visible = false;
            budgetPage.Visible = false;

        }



        private void btnWallet_Click(object sender, EventArgs e)
        {
            walletPage.connectionString = connectionString;
            walletPage.runWallet();

            homePage.Visible = false;
            walletPage.Visible = true;
            CategoryPage.Visible = false;
            budgetPage.Visible = false;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            CategoryPage.connectionString = connectionString;
            CategoryPage.runCategory();

            homePage.Visible = false;
            walletPage.Visible = false;
            CategoryPage.Visible = true;
            budgetPage.Visible = false;
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            budgetPage.connectionString = connectionString;
            budgetPage.runBudget();

            homePage.Visible = false;
            walletPage.Visible = false;
            CategoryPage.Visible =false;
            budgetPage.Visible = true;
        }
    }
}
