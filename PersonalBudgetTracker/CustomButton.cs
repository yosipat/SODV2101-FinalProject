using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PersonalBudgetTracker
{
    public class CustomButton : Button
    {
        private Color originalBackColor; // To store the original background color

        public CustomButton()
        {
            // Set default styles for the button
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.White; // Default background color
            this.ForeColor = Color.Black; // Default text color
            this.Font = new Font("Arial", 10, FontStyle.Bold); // Default font
            // Avoid setting a fixed size to support designer adjustments
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Prevent execution in design mode
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            // Set the GraphicsPath for rounded corners dynamically
            using (GraphicsPath path = CreateRoundRectanglePath(this.ClientRectangle, 20)) // 20 is the corner radius
            {
                this.Region = new Region(path);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            originalBackColor = this.BackColor; // Save the current background color
            this.BackColor = Color.LightGray; // Change color on hover
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = originalBackColor; // Restore the original background color when hover ends
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.BackColor = Color.Gray; // Change color on mouse down
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.BackColor = Color.LightGray; // Restore to hover color when mouse up
        }

        /// <summary>
        /// Creates a GraphicsPath with rounded corners.
        /// </summary>
        /// <param name="rect">The rectangle area of the button</param>
        /// <param name="cornerRadius">The radius of the rounded corners</param>
        /// <returns>A GraphicsPath object representing the rounded rectangle</returns>
        private GraphicsPath CreateRoundRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.Left, rect.Top, cornerRadius, cornerRadius, 180, 90); // Top-left corner
            path.AddArc(rect.Right - cornerRadius, rect.Top, cornerRadius, cornerRadius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right corner
            path.AddArc(rect.Left, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left corner
            path.CloseFigure();
            return path;
        }
    }
}
