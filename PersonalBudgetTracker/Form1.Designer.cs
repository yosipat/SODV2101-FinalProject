namespace PersonalBudgetTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblApp = new Label();
            pictureBox1 = new PictureBox();
            btnStart = new Button();
            txtName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblApp
            // 
            lblApp.AutoSize = true;
            lblApp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApp.Location = new Point(71, 46);
            lblApp.Name = "lblApp";
            lblApp.Size = new Size(142, 25);
            lblApp.TabIndex = 0;
            lblApp.Text = "Budget Tracker";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(92, 91);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.ButtonFace;
            btnStart.Location = new Point(85, 274);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(128, 34);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.InactiveCaption;
            txtName.Location = new Point(61, 227);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Enter your Name";
            txtName.Size = new Size(174, 31);
            txtName.TabIndex = 3;
            txtName.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(294, 381);
            Controls.Add(txtName);
            Controls.Add(btnStart);
            Controls.Add(pictureBox1);
            Controls.Add(lblApp);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Budget Tracker";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblApp;
        private PictureBox pictureBox1;
        private Button btnStart;
        private TextBox txtName;
    }
}
