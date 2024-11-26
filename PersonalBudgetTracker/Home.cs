
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

        string[] month = { "Janurary", "February","March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public class BarChart()
        {
            public string Month;
            public float Amount;
            public string Type;
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
                    string query = "SELECT DISTINCT DATENAME(month, wDate) AS month FROM Wallet";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(reader);

                        foreach (DataRow row in data.Rows)
                        {
                            cbMonth.Items.Add(row["month"]);
                        }

                        // Set SelectedIndex only if items exist
                        if (cbMonth.Items.Count > 0)
                        {
                            cbMonth.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail: " + ex.ToString());
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
                    {
                        string query = "Select wType,sum(Amount) as Amount,(DATENAME(month, wDate)) as month from Wallet group by (DATENAME(month, wDate)),wType";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            DataTable data = new DataTable();
                            data.Load(reader);

                            foreach (DataRow row in data.Rows)
                            {
                                bars.Add(new BarChart
                                {
                                    Month = row["month"].ToString(),
                                    Amount = (float)Convert.ToDouble(row["Amount"]),
                                    Type = row["wType"].ToString()
                                });
                            }
                        }
                        panelBar.Invalidate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail :" + ex.ToString());
                }
            }
        }

        public void LoadMonthData()
        {
            TotalBalance = 0;
            TotalIncome = 0;
            TotalExpense = 0;

            string filter = " where DATENAME(month, wDate)=" + "'" + cbMonth.Text + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    {
                        string query = "Select * from Wallet" + filter;
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            DataTable data = new DataTable();
                            data.Load(reader);

                            //dataGridView1.DataSource = data;
                            //dataGridView1.Columns[0].Width = 50;

                            foreach (DataRow row in data.Rows)
                            {
                                if (row["wType"].ToString() == "Income")
                                {
                                    TotalIncome += Convert.ToDouble(row["Amount"]);
                                }
                                if (row["wType"].ToString() == "Expense")
                                {
                                    TotalExpense += Convert.ToDouble(row["Amount"]);
                                }
                            }

                            lblIncome.Text = "$" + TotalIncome.ToString();
                            lblExpense.Text = "$" + TotalExpense.ToString();
                        }
                    }

                    TotalBalance = TotalIncome - TotalExpense;
                    lblBalance.Text = "$" + TotalBalance.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail :" + ex.ToString());
                }
            }
        }


        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMonthData();
            panelPie.Invalidate(); // Trigger the paint event
        }

        private void panelPie_Paint(object sender, PaintEventArgs e)
        {
            // Get the Graphics object to draw on the form
            Graphics g = e.Graphics;

            // Set the width and height for the pie chart
            int width = 200;
            int height = 200;

            // Set the position for the pie chart (center of the form)
            int x = (panelPie.Width - width) / 2;
            int y = (panelPie.Height - height) / 2;

            // Create a rectangle that defines the bounds of the pie chart
            Rectangle pieBounds = new Rectangle(x, y, width, height);

            // Calculate the total sum of the data
            float total = (float)TotalBalance;

            float[] data = { (float)TotalIncome, (float)TotalExpense };
            string[] categories = { "Income", "Expense" };

            // Colors for each slice
            Color[] sliceColors = { Color.Green, Color.Red };

            // Start drawing the pie chart
            float startAngle = 0;
            for (int i = 0; i < data.Length; i++)
            {
                // Calculate the angle for each slice
                float sweepAngle = (data[i] / total) * 360;



                // Draw the slice of the pie chart
                g.FillPie(new SolidBrush(sliceColors[i]), pieBounds, startAngle, sweepAngle);

                // Increment the start angle for the next slice
                startAngle += sweepAngle;
            }

            // Draw the labels for each slice
            startAngle = 0;
            for (int i = 0; i < data.Length; i++)
            {
                // Calculate the angle for the label
                float sweepAngle = (data[i] / total) * 360;
                float labelAngle = startAngle + sweepAngle / 2;

                // Convert the angle to radians
                float labelAngleRadians = labelAngle * (float)Math.PI / 180;

                // Calculate the position of the label
                int labelX = x + (int)(width / 2 + Math.Cos(labelAngleRadians) * width / 4);
                int labelY = y + (int)(height / 2 + Math.Sin(labelAngleRadians) * height / 4);


                if (data[i] > 0) // Draw the label if data > 0
                {
                    g.DrawString(categories[i], this.Font, Brushes.Black, labelX, labelY);
                }


                // Update the start angle for the next slice
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
            int originY = panelBar.Height -30; // Starting y position

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
                        Color color = (b.Type=="Income")?Color.Green:Color.Red;
                    Brush brush= (b.Type == "Income") ? Brushes.Green : Brushes.Red;
                    g.FillRectangle(new SolidBrush(color), x, y, barWidth, Math.Abs(height));

                        SizeF sizeValue = g.MeasureString(value.ToString(), this.Font);
                        SizeF sizeName = g.MeasureString(name.Substring(0, 3), this.Font);

                        // label the bar
                        g.DrawString(name.Substring(0,3), this.Font, Brushes.Blue, x + (barWidth - sizeName.Width) / 2, height > 0 ? y + height : y - 30);
                        g.DrawString(value.ToString(), this.Font, brush, x + (barWidth - sizeValue.Width) / 2, height > 0 ? y - 30 : y + Math.Abs(height));
                        index++;
                  
                    
                    


                    //MessageBox.Show(name + income.ToString()+" "+expense.ToString());



                    
                }
                index++;

            }
        }
    }
}
