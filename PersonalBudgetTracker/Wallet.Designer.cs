namespace PersonalBudgetTracker
{
    partial class Wallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wallet));
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            cbType = new ComboBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            label5 = new Label();
            label4 = new Label();
            txtAmount = new TextBox();
            dtDate = new DateTimePicker();
            label3 = new Label();
            cbCategory = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            lblBalance = new Label();
            pictureBox1 = new PictureBox();
            btnExport = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.WindowText;
            dataGridView1.Location = new Point(53, 126);
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
            dataGridView1.Size = new Size(592, 366);
            dataGridView1.TabIndex = 1;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbType);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtAmount);
            groupBox1.Controls.Add(dtDate);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(692, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 468);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Transaction";
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(27, 80);
            cbType.Name = "cbType";
            cbType.Size = new Size(352, 33);
            cbType.TabIndex = 11;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 305);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 7;
            label5.Text = "Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 220);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 6;
            label4.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(27, 248);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(352, 31);
            txtAmount.TabIndex = 5;
            // 
            // dtDate
            // 
            dtDate.Location = new Point(27, 333);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(352, 31);
            dtDate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 131);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 3;
            label3.Text = "Category";
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(27, 159);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(352, 33);
            cbCategory.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 52);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 1;
            label1.Text = "Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(53, 57);
            label2.Name = "label2";
            label2.Size = new Size(97, 38);
            label2.TabIndex = 16;
            label2.Text = "Wallet";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.BackColor = SystemColors.GradientInactiveCaption;
            lblBalance.Location = new Point(458, 68);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(75, 25);
            lblBalance.TabIndex = 17;
            lblBalance.Text = "Balance:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(402, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // btnExport
            // 
            btnExport.BackColor = SystemColors.ButtonFace;
            btnExport.Location = new Point(533, 511);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(112, 34);
            btnExport.TabIndex = 22;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.GradientInactiveCaption;
            label8.Location = new Point(385, 52);
            label8.Name = "label8";
            label8.Size = new Size(260, 57);
            label8.TabIndex = 20;
            // 
            // Wallet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnExport);
            Controls.Add(pictureBox1);
            Controls.Add(lblBalance);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label8);
            Name = "Wallet";
            Size = new Size(1140, 570);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Label label3;
        private ComboBox cbCategory;
        private Label label1;
        private Label label2;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label label5;
        private Label label4;
        private TextBox txtAmount;
        private DateTimePicker dtDate;
        private ComboBox cbType;
        private Label lblBalance;
        private PictureBox pictureBox1;
        private Button btnExport;
        private Label label8;
    }
}
