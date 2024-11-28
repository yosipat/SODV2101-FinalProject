namespace PersonalBudgetTracker
{
    partial class Budget
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Budget));
            label1 = new Label();
            dataGridView1 = new DataGridView();
            cbCategory = new ComboBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            textBox1 = new TextBox();
            lblBudgetLimit = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            lblCategory = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lblTotalExpense = new Label();
            lblTotalBudget = new Label();
            lblControl = new Label();
            lblRemainingBudget = new Label();
            pictureBox3 = new PictureBox();
            label8 = new Label();
            lblBudgetedIncome = new Label();
            lblTotalIncome = new Label();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(53, 57);
            label1.Name = "label1";
            label1.Size = new Size(109, 38);
            label1.TabIndex = 0;
            label1.Text = "Budget";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.WindowText;
            dataGridView1.Location = new Point(53, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(592, 290);
            dataGridView1.TabIndex = 2;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(27, 80);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(352, 33);
            cbCategory.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lblBudgetLimit);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(lblCategory);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Location = new Point(692, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 468);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Manage Budget";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 316);
            label2.Name = "label2";
            label2.Size = new Size(133, 25);
            label2.TabIndex = 14;
            label2.Text = "Filter by Month";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(267, 212);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(149, 212);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 212);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 159);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(352, 31);
            textBox1.TabIndex = 8;
            // 
            // lblBudgetLimit
            // 
            lblBudgetLimit.AutoSize = true;
            lblBudgetLimit.Location = new Point(27, 131);
            lblBudgetLimit.Name = "lblBudgetLimit";
            lblBudgetLimit.Size = new Size(112, 25);
            lblBudgetLimit.TabIndex = 7;
            lblBudgetLimit.Text = "Budget Limit\n";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(27, 360);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(352, 33);
            comboBox1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(267, 409);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 5;
            button1.Text = "Filter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(27, 52);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(84, 25);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(65, 481);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 31;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(328, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // lblTotalExpense
            // 
            lblTotalExpense.AutoSize = true;
            lblTotalExpense.BackColor = SystemColors.GradientInactiveCaption;
            lblTotalExpense.Location = new Point(103, 486);
            lblTotalExpense.Name = "lblTotalExpense";
            lblTotalExpense.Size = new Size(122, 25);
            lblTotalExpense.TabIndex = 28;
            lblTotalExpense.Text = "Total Expense:";
            // 
            // lblTotalBudget
            // 
            lblTotalBudget.AutoSize = true;
            lblTotalBudget.BackColor = SystemColors.GradientInactiveCaption;
            lblTotalBudget.Location = new Point(103, 445);
            lblTotalBudget.Name = "lblTotalBudget";
            lblTotalBudget.Size = new Size(115, 25);
            lblTotalBudget.TabIndex = 27;
            lblTotalBudget.Text = "Total Budget:";
            // 
            // lblControl
            // 
            lblControl.BackColor = SystemColors.GradientInactiveCaption;
            lblControl.Location = new Point(53, 428);
            lblControl.Name = "lblControl";
            lblControl.Size = new Size(592, 99);
            lblControl.TabIndex = 29;
            // 
            // lblRemainingBudget
            // 
            lblRemainingBudget.AutoSize = true;
            lblRemainingBudget.BackColor = SystemColors.GradientInactiveCaption;
            lblRemainingBudget.Location = new Point(369, 57);
            lblRemainingBudget.Name = "lblRemainingBudget";
            lblRemainingBudget.Size = new Size(161, 25);
            lblRemainingBudget.TabIndex = 32;
            lblRemainingBudget.Text = "Remaining Budget:";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(65, 440);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 35);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 33;
            pictureBox3.TabStop = false;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.GradientInactiveCaption;
            label8.Location = new Point(305, 46);
            label8.Name = "label8";
            label8.Size = new Size(340, 57);
            label8.TabIndex = 34;
            // 
            // Budget
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox3);
            Controls.Add(lblRemainingBudget);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblTotalExpense);
            Controls.Add(lblTotalBudget);
            Controls.Add(lblControl);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(label8);
            Name = "Budget";
            Size = new Size(1140, 570);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox cbCategory;
        private GroupBox groupBox1;
        private Label lblCategory;
        private Button button1;
        private Label lblBudgetLimit;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label label2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblTotalExpense;
        private Label lblTotalBudget;
        private Label lblControl;
        private Label lblRemainingBudget;
        private PictureBox pictureBox3;
        private Label label8;
    }
}
