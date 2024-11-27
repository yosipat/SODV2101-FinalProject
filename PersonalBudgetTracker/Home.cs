using Microsoft.Data.SqlClient;
using System.Data;

namespace PersonalBudgetTracker
{
    public partial class Home : UserControl
    {
        public string connectionString { get; set; }

        double TotalBalance = 0;
        double TotalIncome = 0;
        double TotalExpense = 0;

        string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public class BarChart
        {
            public string Month { get; set; }
            public float Amount { get; set; }
            public string Type { get; set; }
        }

        List<BarChart> bars = new List<BarChart>();

        public Home()
        {
            InitializeComponent();
        }

        public void runHomePage()
        {
            bars.Clear();
            LoadFilter();
            LoadAllData();
            LoadMonthData();
        }

        public void LoadFilter()
        {
            cbMonth.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT DATENAME(month, TransactionDate) AS Month FROM Wallet";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cbMonth.Items.Add(reader["Month"].ToString());
                        }

                        if (cbMonth.Items.Count > 0)
                        {
                            cbMonth.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading filters: " + ex.Message);
                }
            }
        }

        public void LoadAllData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT c.CategoryType, SUM(w.Amount) AS Amount, DATENAME(month, w.TransactionDate) AS Month
                        FROM Wallet w
                        JOIN Categories c ON w.CategoryID = c.CategoryID
                        GROUP BY DATENAME(month, w.TransactionDate), c.CategoryType
                    ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            bars.Add(new BarChart
                            {
                                Month = reader["Month"].ToString(),
                                Amount = Convert.ToSingle(reader["Amount"]),
                                Type = reader["CategoryType"].ToString()
                            });
                        }
                        panelBar.Invalidate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        public void LoadMonthData()
        {
            TotalBalance = 0;
            TotalIncome = 0;
            TotalExpense = 0;

            string filter = "WHERE DATENAME(month, TransactionDate) = @SelectedMonth";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT c.CategoryType, w.Amount
                        FROM Wallet w
                        JOIN Categories c ON w.CategoryID = c.CategoryID
                        " + filter;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SelectedMonth", cbMonth.Text);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string transactionType = reader["CategoryType"].ToString();
                            double amount = Convert.ToDouble(reader["Amount"]);

                            if (transactionType == "Income")
                                TotalIncome += amount;
                            else if (transactionType == "Expense")
                                TotalExpense += amount;
                        }

                        lblIncome.Text = $"${TotalIncome:F2}";
                        lblExpense.Text = $"${TotalExpense:F2}";
                    }

                    TotalBalance = TotalIncome - TotalExpense;
                    lblBalance.Text = $"${TotalBalance:F2}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading monthly data: " + ex.Message);
                }
            }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMonthData();
            panelPie.Invalidate();
        }

        private void panelPie_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = 200, height = 200;
            int x = (panelPie.Width - width) / 2;
            int y = (panelPie.Height - height) / 2;

            Rectangle pieBounds = new Rectangle(x, y, width, height);
            float total = (float)(TotalIncome + TotalExpense);

            if (total == 0) return;

            float[] data = { (float)TotalIncome, (float)TotalExpense };
            Color[] colors = { Color.Green, Color.Red };
            string[] labels = { "Income", "Expense" };

            float startAngle = 0;
            for (int i = 0; i < data.Length; i++)
            {
                float sweepAngle = (data[i] / total) * 360;
                g.FillPie(new SolidBrush(colors[i]), pieBounds, startAngle, sweepAngle);

                // Calculate the percentage
                float percentage = (data[i] / total) * 100;

                // Draw the percentage text on the pie slice farther from the center
                string percentText = $"{percentage:F1}%";

                // Place the text slightly away from the center of the pie
                float centerX = x + width / 2;
                float centerY = y + height / 2;

                // Adjust the distance for how far the text should be placed from the center
                float distance = width / 3.0f; 

                // Measure the size of the string to center it
                SizeF textSize = g.MeasureString(percentText, new Font("Arial", 8));

                // Position the text at a distance from the center, while keeping it in the correct direction
                float angle = startAngle + sweepAngle / 2;
                float textX = centerX + (float)(Math.Cos(angle * Math.PI / 180) * distance) - textSize.Width / 2;
                float textY = centerY + (float)(Math.Sin(angle * Math.PI / 180) * distance) - textSize.Height / 2;

                // Draw the percentage text
                g.DrawString(percentText, new Font("Arial", 8), Brushes.Black, new PointF(textX, textY));

                startAngle += sweepAngle;
            }
        }



        private void panelBar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 1);

            int barWidth = 40;
            int spacing = 10; // space between bar
            int originX = 20; // Starting x position
            int originY = panelBar.Height - 30; // Starting y position

            // draw x-axis
            g.DrawLine(blackPen, originX, originY, panelBar.Width - originX, originY);
            g.DrawString("x", this.Font, Brushes.Black, panelBar.Width - originX, originY - 15);
            // draw y-axis
            g.DrawLine(blackPen, originX, originY - panelBar.Height / 2 + 30, originX, originY + panelBar.Height / 2 - 30);
            g.DrawString("y", this.Font, Brushes.Black, originX - 5, originY - panelBar.Height / 2);


            if (bars == null || bars.Count == 0) // check Is data null?
                return;


            List<float> values = new List<float>();
            foreach (BarChart data in bars)
            {
                values.Add(data.Amount);
            }

            float max = values.Max();
            float min = values.Min();



            int index = 0;
            for (int i = 0; i < month.Length; i++)
            {
                string name = month[i];
                float income = 0;
                float expense = 0;

                var barvalue = bars.Where(b => b.Month == month[i]);
                foreach (BarChart b in barvalue)
                {

                    float value = b.Amount;

                    // Calculate the height and position
                    float height = (float)((value * 100) / (Math.Abs(max) > Math.Abs(min) ? Math.Abs(max) : Math.Abs(min)));
                    float x = originX + index * (barWidth + spacing);
                    float y = height > 0 ? originY - height : originY;

                    //MessageBox.Show(height.ToString());

                    // Draw the bar
                    Color color = (b.Type == "Income") ? Color.Green : Color.Red;
                    Brush brush = (b.Type == "Income") ? Brushes.Green : Brushes.Red;
                    g.FillRectangle(new SolidBrush(color), x, y, barWidth, Math.Abs(height));

                    SizeF sizeValue = g.MeasureString(value.ToString(), this.Font);
                    SizeF sizeName = g.MeasureString(name.Substring(0, 3), this.Font);

                    // label the bar
                    g.DrawString(name.Substring(0, 3), this.Font, Brushes.Blue, x + (barWidth - sizeName.Width) / 2, height > 0 ? y + height : y - 30);
                    g.DrawString(value.ToString(), this.Font, brush, x + (barWidth - sizeValue.Width) / 2, height > 0 ? y - 30 : y + Math.Abs(height));
                    index++;





                    //MessageBox.Show(name + income.ToString()+" "+expense.ToString());




                }
                index++;

            }
        }

    }
}
