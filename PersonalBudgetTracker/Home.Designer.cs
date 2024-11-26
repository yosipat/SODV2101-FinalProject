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
            lblBalance = new Label();
            lblIncome = new Label();
            lblExpense = new Label();
            cbMonth = new ComboBox();
            panelPie = new Panel();
            label1 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            label8 = new Label();
            label2 = new Label();
            panelBar = new Panel();
            SuspendLayout();
            // 
            // lblBalance
            // 
            lblBalance.BackColor = SystemColors.ControlLight;
            lblBalance.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalance.Location = new Point(34, 161);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(237, 72);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "label1";
            lblBalance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIncome
            // 
            lblIncome.BackColor = SystemColors.ControlLight;
            lblIncome.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIncome.Location = new Point(299, 161);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(237, 72);
            lblIncome.TabIndex = 2;
            lblIncome.Text = "label1";
            lblIncome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblExpense
            // 
            lblExpense.BackColor = SystemColors.ControlLight;
            lblExpense.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExpense.Location = new Point(564, 161);
            lblExpense.Name = "lblExpense";
            lblExpense.Size = new Size(237, 72);
            lblExpense.TabIndex = 3;
            lblExpense.Text = "label1";
            lblExpense.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbMonth
            // 
            cbMonth.FormattingEnabled = true;
            cbMonth.Location = new Point(192, 40);
            cbMonth.Name = "cbMonth";
            cbMonth.Size = new Size(182, 33);
            cbMonth.TabIndex = 4;
            cbMonth.SelectedIndexChanged += cbMonth_SelectedIndexChanged;
            // 
            // panelPie
            // 
            panelPie.Location = new Point(864, 33);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(200, 200);
            panelPie.TabIndex = 5;
            panelPie.Paint += panelPie_Paint;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.Location = new Point(34, 111);
            label1.Name = "label1";
            label1.Size = new Size(237, 50);
            label1.TabIndex = 6;
            label1.Text = "Balance Overview";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ControlLight;
            label4.Location = new Point(34, 111);
            label4.Name = "label4";
            label4.Size = new Size(237, 122);
            label4.TabIndex = 9;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ControlLight;
            label6.Location = new Point(564, 111);
            label6.Name = "label6";
            label6.Size = new Size(237, 50);
            label6.TabIndex = 11;
            label6.Text = "Total Expense";
            label6.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ControlLight;
            label7.Location = new Point(564, 111);
            label7.Name = "label7";
            label7.Size = new Size(237, 122);
            label7.TabIndex = 12;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ControlLight;
            label5.Location = new Point(299, 111);
            label5.Name = "label5";
            label5.Size = new Size(237, 50);
            label5.TabIndex = 13;
            label5.Text = "Total Income";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ControlLight;
            label8.Location = new Point(299, 111);
            label8.Name = "label8";
            label8.Size = new Size(237, 122);
            label8.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 37);
            label2.Name = "label2";
            label2.Size = new Size(152, 32);
            label2.TabIndex = 15;
            label2.Text = "Summary By";
            // 
            // panelBar
            // 
            panelBar.Location = new Point(34, 292);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1030, 238);
            panelBar.TabIndex = 16;
            panelBar.Paint += panelBar_Paint;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBar);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(cbMonth);
            Controls.Add(label1);
            Controls.Add(panelPie);
            Controls.Add(lblExpense);
            Controls.Add(lblIncome);
            Controls.Add(lblBalance);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(label7);
            Name = "Home";
            Size = new Size(1140, 570);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblBalance;
        private Label lblIncome;
        private Label lblExpense;
        private ComboBox cbMonth;
        private Panel panelPie;
        private Label label1;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label5;
        private Label label8;
        private Label label2;
        private Panel panelBar;
    }
}
