
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Budget));
            label1 = new Label();
            dataGridView1 = new DataGridView();
            cbCategory = new ComboBox();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtBudgetLimit = new TextBox();
            lblBudgetLimit = new Label();
            cbFilterMonth = new ComboBox();
            btnFilter = new Button();
            lblCategory = new Label();
            pictureBox1 = new PictureBox();
            lblRemainingBudget = new Label();
            label8 = new Label();
            btnExport = new Button();
            cbFilterCategory = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(592, 370);
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
            groupBox1.Controls.Add(cbFilterCategory);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(txtBudgetLimit);
            groupBox1.Controls.Add(lblBudgetLimit);
            groupBox1.Controls.Add(btnFilter);
            groupBox1.Controls.Add(lblCategory);
            groupBox1.Controls.Add(cbFilterMonth);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Location = new Point(692, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 468);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Manage Budget";
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
            // txtBudgetLimit
            // 
            txtBudgetLimit.Location = new Point(27, 159);
            txtBudgetLimit.Name = "txtBudgetLimit";
            txtBudgetLimit.Size = new Size(352, 31);
            txtBudgetLimit.TabIndex = 8;
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
            // cbFilterMonth
            // 
            cbFilterMonth.FormattingEnabled = true;
            cbFilterMonth.Location = new Point(27, 357);
            cbFilterMonth.Name = "cbFilterMonth";
            cbFilterMonth.Size = new Size(178, 33);
            cbFilterMonth.TabIndex = 6;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(267, 409);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(112, 34);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
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
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(407, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // lblRemainingBudget
            // 
            lblRemainingBudget.AutoSize = true;
            lblRemainingBudget.BackColor = SystemColors.GradientInactiveCaption;
            lblRemainingBudget.Location = new Point(448, 61);
            lblRemainingBudget.Name = "lblRemainingBudget";
            lblRemainingBudget.Size = new Size(161, 25);
            lblRemainingBudget.TabIndex = 32;
            lblRemainingBudget.Text = "Remaining Budget:";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.GradientInactiveCaption;
            label8.Location = new Point(385, 46);
            label8.Name = "label8";
            label8.Size = new Size(260, 57);
            label8.TabIndex = 34;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(533, 508);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(112, 34);
            btnExport.TabIndex = 35;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // cbFilterCategory
            // 
            cbFilterCategory.FormattingEnabled = true;
            cbFilterCategory.Location = new Point(211, 357);
            cbFilterCategory.Name = "cbFilterCategory";
            cbFilterCategory.Size = new Size(168, 33);
            cbFilterCategory.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 319);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 16;
            label2.Text = "Filter";
            // 
            // Budget
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnExport);
            Controls.Add(lblRemainingBudget);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(label8);
            Name = "Budget";
            Size = new Size(1140, 570);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void lblBudgetedExpense_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion


        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox cbCategory;
        private GroupBox groupBox1;
        private Label lblCategory;
        private Button btnFilter;
        private Label lblBudgetLimit;
        private ComboBox cbFilterMonth;
        private TextBox txtBudgetLimit;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private PictureBox pictureBox1;
        private Label lblRemainingBudget;
        private Label label8;
        private Button btnExport;
        private ComboBox cbFilterCategory;
        private Label label2;
    }
}
