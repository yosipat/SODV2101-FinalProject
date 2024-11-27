namespace PersonalBudgetTracker
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            lblBalance = new Label();
            cbMonth = new ComboBox();
            panelPie = new Panel();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            panelBar = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            lblIncome = new Label();
            label10 = new Label();
            pictureBox3 = new PictureBox();
            label5 = new Label();
            lblExpense = new Label();
            label9 = new Label();
            label6 = new Label();
            panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblBalance
            // 
            lblBalance.BackColor = SystemColors.ControlLight;
            lblBalance.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblBalance.Location = new Point(114, 160);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(169, 60);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "label1";
            lblBalance.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbMonth
            // 
            cbMonth.FormattingEnabled = true;
            cbMonth.Location = new Point(317, 40);
            cbMonth.Name = "cbMonth";
            cbMonth.Size = new Size(182, 33);
            cbMonth.TabIndex = 4;
            cbMonth.SelectedIndexChanged += cbMonth_SelectedIndexChanged;
            // 
            // panelPie
            // 
            panelPie.Location = new Point(894, 33);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(200, 200);
            panelPie.TabIndex = 5;
            panelPie.Paint += panelPie_Paint;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.ForeColor = SystemColors.WindowFrame;
            label1.Location = new Point(114, 125);
            label1.Name = "label1";
            label1.Size = new Size(169, 35);
            label1.TabIndex = 6;
            label1.Text = "Balance Overview";
            label1.TextAlign = ContentAlignment.BottomRight;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ControlLight;
            label4.Location = new Point(34, 111);
            label4.Name = "label4";
            label4.Size = new Size(259, 122);
            label4.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 37);
            label2.Name = "label2";
            label2.Size = new Size(276, 32);
            label2.TabIndex = 15;
            label2.Text = "Dashboard Summary by";
            // 
            // panelBar
            // 
            panelBar.Controls.Add(label6);
            panelBar.Location = new Point(34, 278);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1060, 226);
            panelBar.TabIndex = 16;
            panelBar.Paint += panelBar_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(48, 160);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlLight;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(325, 160);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ControlLight;
            label3.ForeColor = SystemColors.WindowFrame;
            label3.Location = new Point(391, 125);
            label3.Name = "label3";
            label3.Size = new Size(169, 35);
            label3.TabIndex = 19;
            label3.Text = "Total Income";
            label3.TextAlign = ContentAlignment.BottomRight;
            // 
            // lblIncome
            // 
            lblIncome.BackColor = SystemColors.ControlLight;
            lblIncome.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblIncome.Location = new Point(391, 160);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(169, 60);
            lblIncome.TabIndex = 18;
            lblIncome.Text = "label1";
            lblIncome.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.BackColor = SystemColors.ControlLight;
            label10.Location = new Point(311, 111);
            label10.Name = "label10";
            label10.Size = new Size(259, 122);
            label10.TabIndex = 20;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ControlLight;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(601, 160);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(60, 60);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 25;
            pictureBox3.TabStop = false;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ControlLight;
            label5.ForeColor = SystemColors.WindowFrame;
            label5.Location = new Point(667, 125);
            label5.Name = "label5";
            label5.Size = new Size(169, 35);
            label5.TabIndex = 23;
            label5.Text = "Total Expense";
            label5.TextAlign = ContentAlignment.BottomRight;
            // 
            // lblExpense
            // 
            lblExpense.BackColor = SystemColors.ControlLight;
            lblExpense.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblExpense.Location = new Point(667, 160);
            lblExpense.Name = "lblExpense";
            lblExpense.Size = new Size(169, 60);
            lblExpense.TabIndex = 22;
            lblExpense.Text = "label1";
            lblExpense.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.BackColor = SystemColors.ControlLight;
            label9.Location = new Point(587, 111);
            label9.Name = "label9";
            label9.Size = new Size(259, 122);
            label9.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(184, 32);
            label6.TabIndex = 26;
            label6.Text = "Yearly overview";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox3);
            Controls.Add(label5);
            Controls.Add(lblExpense);
            Controls.Add(label9);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(lblIncome);
            Controls.Add(label10);
            Controls.Add(pictureBox1);
            Controls.Add(panelBar);
            Controls.Add(label2);
            Controls.Add(cbMonth);
            Controls.Add(label1);
            Controls.Add(panelPie);
            Controls.Add(lblBalance);
            Controls.Add(label4);
            Name = "Home";
            Size = new Size(1140, 570);
            panelBar.ResumeLayout(false);
            panelBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblBalance;
        private ComboBox cbMonth;
        private Panel panelPie;
        private Label label1;
        private Label label4;
        private Label label2;
        private Panel panelBar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label lblIncome;
        private Label label10;
        private PictureBox pictureBox3;
        private Label label5;
        private Label lblExpense;
        private Label label9;
        private Label label6;
    }
}
