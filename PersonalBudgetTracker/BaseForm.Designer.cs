namespace PersonalBudgetTracker
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            lblName = new Label();
            lblUserName = new Label();
            panel1 = new Panel();
            btnBudget = new CustomButton();
            btnSettings = new CustomButton();
            btnWallet = new CustomButton();
            btnCategory = new CustomButton();
            btnHome = new CustomButton();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            homePage = new Home();
            walletPage = new Wallet();
            settingPage = new Setting();
            CategoryPage = new Category();
            budgetPage = new Budget();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblName.Location = new Point(173, 31);
            lblName.Name = "lblName";
            lblName.Size = new Size(385, 45);
            lblName.TabIndex = 0;
            lblName.Text = "Personal Budget Tracker";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(173, 89);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(95, 25);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Hello, user";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(btnBudget);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(btnWallet);
            panel1.Controls.Add(btnCategory);
            panel1.Controls.Add(btnHome);
            panel1.Location = new Point(0, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(308, 570);
            panel1.TabIndex = 2;
            // 
            // btnBudget
            // 
            btnBudget.BackColor = Color.White;
            btnBudget.FlatAppearance.BorderSize = 0;
            btnBudget.FlatStyle = FlatStyle.Flat;
            btnBudget.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBudget.ForeColor = Color.Black;
            btnBudget.Image = (Image)resources.GetObject("btnBudget.Image");
            btnBudget.Location = new Point(48, 215);
            btnBudget.Name = "btnBudget";
            btnBudget.Size = new Size(206, 67);
            btnBudget.TabIndex = 4;
            btnBudget.Text = " Budget";
            btnBudget.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBudget.UseVisualStyleBackColor = false;
            btnBudget.Click += btnBudget_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.White;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSettings.ForeColor = Color.Black;
            btnSettings.Image = Properties.Resources.setting;
            btnSettings.Location = new Point(48, 387);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(206, 67);
            btnSettings.TabIndex = 3;
            btnSettings.Text = " Settings";
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnWallet
            // 
            btnWallet.BackColor = Color.White;
            btnWallet.FlatAppearance.BorderSize = 0;
            btnWallet.FlatStyle = FlatStyle.Flat;
            btnWallet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnWallet.ForeColor = Color.Black;
            btnWallet.Image = Properties.Resources.wallet;
            btnWallet.Location = new Point(48, 129);
            btnWallet.Name = "btnWallet";
            btnWallet.Size = new Size(206, 67);
            btnWallet.TabIndex = 2;
            btnWallet.Text = " Wallet";
            btnWallet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWallet.UseVisualStyleBackColor = false;
            btnWallet.Click += btnWallet_Click;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.White;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCategory.ForeColor = Color.Black;
            btnCategory.Image = Properties.Resources.category;
            btnCategory.Location = new Point(48, 301);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(206, 67);
            btnCategory.TabIndex = 1;
            btnCategory.Text = " Category";
            btnCategory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.White;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.Black;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.Location = new Point(48, 43);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(206, 67);
            btnHome.TabIndex = 0;
            btnHome.Text = " Home";
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(48, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(lblName);
            panel2.Controls.Add(lblUserName);
            panel2.Location = new Point(0, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1454, 156);
            panel2.TabIndex = 5;
            // 
            // homePage
            // 
            homePage.connectionString = null;
            homePage.Location = new Point(310, 155);
            homePage.Name = "homePage";
            homePage.Size = new Size(1710, 855);
            homePage.TabIndex = 6;
            // 
            // walletPage
            // 
            walletPage.connectionString = null;
            walletPage.Location = new Point(310, 155);
            walletPage.Name = "walletPage";
            walletPage.Size = new Size(1710, 855);
            walletPage.TabIndex = 7;
            // 
            // settingPage
            // 
            settingPage.connectionString = null;
            settingPage.Location = new Point(310, 155);
            settingPage.Name = "settingPage";
            settingPage.Size = new Size(1710, 855);
            settingPage.TabIndex = 8;
            // 
            // CategoryPage
            // 
            CategoryPage.connectionString = null;
            CategoryPage.Location = new Point(310, 155);
            CategoryPage.Name = "CategoryPage";
            CategoryPage.Size = new Size(1710, 855);
            CategoryPage.TabIndex = 9;
            // 
            // budgetPage
            // 
            budgetPage.Location = new Point(310, 155);
            budgetPage.Name = "budgetPage";
            budgetPage.Size = new Size(1710, 855);
            budgetPage.TabIndex = 10;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1452, 726);
            Controls.Add(budgetPage);
            Controls.Add(CategoryPage);
            Controls.Add(settingPage);
            Controls.Add(walletPage);
            Controls.Add(homePage);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "BaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personal Budget Tracker";
            FormClosing += BaseForm_FormClosing;
            Load += BaseForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblName;
        private Label lblUserName;
        private Panel panel1;
        private CustomButton btnHome;
        private CustomButton btnSettings;
        private CustomButton btnWallet;
        private CustomButton btnCategory;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Home homePage;
        private Wallet walletPage;
        private Setting settingPage;
        private Category CategoryPage;
        private Budget budgetPage;
        private CustomButton btnBudget;
    }
}