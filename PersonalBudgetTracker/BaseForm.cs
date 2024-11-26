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

        public string connectionString = "Data Source=STEPH-LAPTOP\\SQLEXPRESS; Initial Catalog= BudgetTracker; Integrated Security=True; TrustServerCertificate=true";

        public BaseForm()
        {

            InitializeComponent();

            homePage.Visible = true;
            walletPage.Visible = false;
            budgetPage.Visible = false;
            settingPage.Visible = false;

            homePage.connectionString = connectionString;
            homePage.runHomePage();

            // Add navigation event handlers to buttons
            btnHome.Click += btnHome_Click;
            btnBudget.Click += btnBudget_Click;
            btnWallet.Click += btnWallet_Click;
            btnSettings.Click += btnSettings_Click;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homePage.connectionString = connectionString;
            homePage.runHomePage();

            homePage.Visible = true;
            walletPage.Visible = false;
            budgetPage.Visible = false;
            settingPage.Visible = false;

        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            budgetPage.connectionString = connectionString;
            budgetPage.runBudget();

            homePage.Visible = false;
            walletPage.Visible = false;
            budgetPage.Visible = true;
            settingPage.Visible = false;
        }

        private void btnWallet_Click(object sender, EventArgs e)
        {
            walletPage.connectionString = connectionString;
            walletPage.runWallet();

            homePage.Visible = false;
            walletPage.Visible = true;
            budgetPage.Visible = false;
            settingPage.Visible = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingPage.connectionString = connectionString;
            settingPage.runSetting();

            homePage.Visible = false;
            walletPage.Visible = false;
            budgetPage.Visible = false;
            settingPage.Visible = true;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
