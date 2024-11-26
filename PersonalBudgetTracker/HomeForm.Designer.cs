namespace PersonalBudgetTracker
{
    partial class HomeForm
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
            lblSummary = new Label();
            SuspendLayout();
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSummary.Location = new Point(344, 181);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(123, 32);
            lblSummary.TabIndex = 6;
            lblSummary.Text = "Summary";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 726);
            Controls.Add(lblSummary);
            Name = "HomeForm";
            Text = "HomeForm";
            Controls.SetChildIndex(lblSummary, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSummary;
    }
}