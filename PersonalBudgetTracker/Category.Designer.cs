namespace PersonalBudgetTracker
{
    partial class Category
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Category));
            label2 = new Label();
            groupBox1 = new GroupBox();
            txtCategory = new TextBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            label4 = new Label();
            txtBudgetLimit = new TextBox();
            label3 = new Label();
            label1 = new Label();
            cbType = new ComboBox();
            dataGridViewBudget = new DataGridView();
            lblTotalIncome = new Label();
            lblTotalExpense = new Label();
            pictureBox1 = new PictureBox();
            label8 = new Label();
            pictureBox2 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(51, 51);
            label2.Name = "label2";
            label2.Size = new Size(133, 38);
            label2.TabIndex = 19;
            label2.Text = "Category";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCategory);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtBudgetLimit);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbType);
            groupBox1.Location = new Point(690, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 468);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add / Modify / Delete";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(27, 163);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(352, 31);
            txtCategory.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(267, 404);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(149, 404);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 404);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 220);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 6;
            label4.Text = "Budget Limit";
            // 
            // txtBudgetLimit
            // 
            txtBudgetLimit.Location = new Point(27, 248);
            txtBudgetLimit.Name = "txtBudgetLimit";
            txtBudgetLimit.Size = new Size(352, 31);
            txtBudgetLimit.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 135);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 3;
            label3.Text = "Category";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 50);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 1;
            label1.Text = "Type";
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(27, 78);
            cbType.Name = "cbType";
            cbType.Size = new Size(352, 33);
            cbType.TabIndex = 0;
            // 
            // dataGridViewBudget
            // 
            dataGridViewBudget.AllowUserToAddRows = false;
            dataGridViewBudget.AllowUserToDeleteRows = false;
            dataGridViewBudget.BackgroundColor = SystemColors.Window;
            dataGridViewBudget.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBudget.Location = new Point(51, 101);
            dataGridViewBudget.Name = "dataGridViewBudget";
            dataGridViewBudget.ReadOnly = true;
            dataGridViewBudget.RowHeadersWidth = 62;
            dataGridViewBudget.Size = new Size(592, 340);
            dataGridViewBudget.TabIndex = 17;
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.BackColor = SystemColors.GradientInactiveCaption;
            lblTotalIncome.Location = new Point(97, 473);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new Size(157, 25);
            lblTotalIncome.TabIndex = 21;
            lblTotalIncome.Text = "Budgeted Income:";
            // 
            // lblTotalExpense
            // 
            lblTotalExpense.AutoSize = true;
            lblTotalExpense.BackColor = SystemColors.GradientInactiveCaption;
            lblTotalExpense.Location = new Point(367, 473);
            lblTotalExpense.Name = "lblTotalExpense";
            lblTotalExpense.Size = new Size(162, 25);
            lblTotalExpense.TabIndex = 23;
            lblTotalExpense.Text = "Budgeted Expense:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(59, 468);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.GradientInactiveCaption;
            label8.Location = new Point(51, 452);
            label8.Name = "label8";
            label8.Size = new Size(592, 67);
            label8.TabIndex = 24;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(329, 468);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            // 
            // Category
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblTotalExpense);
            Controls.Add(lblTotalIncome);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridViewBudget);
            Controls.Add(label8);
            Name = "Category";
            Size = new Size(1140, 570);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label label4;
        private TextBox txtBudgetLimit;
        private Label label3;
        private Label label1;
        private ComboBox cbType;
        private DataGridView dataGridViewBudget;
        private TextBox txtCategory;
        private Label lblTotalIncome;
        private Label lblTotalExpense;
        private PictureBox pictureBox1;
        private Label label8;
        private PictureBox pictureBox2;
    }
}
