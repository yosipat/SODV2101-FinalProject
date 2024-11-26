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
        public BaseForm()
        {
            InitializeComponent();

            // Add navigation event handlers to buttons
            btnHome.Click += btnHome_Click;
            btnBudget.Click += btnBudget_Click;
            btnWallet.Click += btnWallet_Click;
            btnSettings.Click += btnSettings_Click;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Check if HomeForm is already open
            if (Application.OpenForms["HomeForm"] == null)
            {
                HomeForm homeForm = new HomeForm();
                homeForm.Show();
            }
            this.Close(); // Close the current form
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            // Check if BudgetForm is already open
            if (Application.OpenForms["BudgetForm"] == null)
            {
                BudgetForm budgetForm = new BudgetForm();
                budgetForm.Show();
            }
            this.Close(); // Close the current form
        }

        private void btnWallet_Click(object sender, EventArgs e)
        {
            // Check if WalletForm is already open
            if (Application.OpenForms["WalletForm"] == null)
            {
                WalletForm walletForm = new WalletForm();
                walletForm.Show();
            }
            this.Close(); // Close the current form
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Check if SettingsForm is already open
            if (Application.OpenForms["SettingsForm"] == null)
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.Show();
            }
            this.Close(); // Close the current form
        }
    }
}
