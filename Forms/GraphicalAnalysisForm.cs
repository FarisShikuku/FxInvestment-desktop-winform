using FxInvestmentAdmin.Services;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FxInvestmentAdmin
{
    public partial class GraphicalAnalysisForm : Form
    {
        private DatabaseService _dbService;

        public GraphicalAnalysisForm()
        {
            InitializeComponent(); // This will be in the designer file
            _dbService = new DatabaseService();
            InitializeChart();
            LoadPeriodComboBox();
            LoadPerformanceData();
        }

        private void InitializeChart()
        {
            // Configure chart area for better appearance
            chartPerformance.ChartAreas[0].AxisX.Title = "Time Period";
            chartPerformance.ChartAreas[0].AxisY.Title = "Cumulative Profit/Loss ($)";
            chartPerformance.ChartAreas[0].AxisX.Interval = 1;
            chartPerformance.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartPerformance.ChartAreas[0].AxisY.LabelStyle.Format = "C";

            // Configure grid lines
            chartPerformance.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartPerformance.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartPerformance.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartPerformance.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            // Clear any existing series
            chartPerformance.Series.Clear();

            // Add main performance series
            var series = new Series("Account Performance");
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.SteelBlue;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.MarkerColor = Color.DarkBlue;
            series.MarkerBorderColor = Color.White;
            series.MarkerBorderWidth = 2;
            series.ToolTip = "Period: #AXISLABEL\nCumulative: #VALY{C2}";

            chartPerformance.Series.Add(series);

            // Enable zoom and scroll
            chartPerformance.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartPerformance.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartPerformance.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chartPerformance.ChartAreas[0].CursorY.IsUserEnabled = true;
            chartPerformance.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartPerformance.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
        }

        private void LoadPeriodComboBox()
        {
            cmbPeriod.Items.AddRange(new object[] {
                "Weekly - Last 12 Weeks",
                "Monthly - Last 12 Months",
                "Quarterly - Last 8 Quarters",
                "Yearly - All Years"
            });
            cmbPeriod.SelectedIndex = 0;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadPerformanceData();
        }

        private void LoadPerformanceData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                chartPerformance.Series[0].Points.Clear();

                string period = cmbPeriod.SelectedItem?.ToString() ?? "Weekly";
                string query = BuildQuery(period);

                var data = _dbService.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    decimal cumulativeProfit = 0;

                    foreach (DataRow row in data.Rows)
                    {
                        string label = GetDataPointLabel(row, period);
                        decimal profit = Convert.ToDecimal(row["results"]);
                        cumulativeProfit += profit;

                        // Add data point to chart
                        int pointIndex = chartPerformance.Series[0].Points.AddXY(label, cumulativeProfit);
                        DataPoint point = chartPerformance.Series[0].Points[pointIndex];

                        // Set point properties
                        point.Label = $"{cumulativeProfit:C0}";
                        point.ToolTip = $"Period: {label}\nCumulative Profit: {cumulativeProfit:C2}\nWeekly P/L: {profit:C2}";

                        // Color points based on weekly profit/loss
                        point.Color = profit >= 0 ? Color.Green : Color.Red;
                        point.MarkerColor = profit >= 0 ? Color.Green : Color.Red;
                        point.MarkerBorderColor = Color.White;
                    }

                    UpdateChartTitle(period, cumulativeProfit);
                    lblStatus.Text = $"Loaded {data.Rows.Count} periods. Final Balance: {cumulativeProfit:C2}";

                    // Auto-adjust Y-axis and reset zoom
                    chartPerformance.ChartAreas[0].RecalculateAxesScale();
                    chartPerformance.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chartPerformance.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }
                else
                {
                    MessageBox.Show("No performance data found for the selected period.", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = "No data found for selected period";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading performance data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error loading data";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private string BuildQuery(string period)
        {
            switch (period)
            {
                case "Weekly - Last 12 Weeks":
                    return @"
                        SELECT week, month, year, results, datetime, fxid 
                        FROM performance 
                        ORDER BY year, week 
                        LIMIT 12";

                case "Monthly - Last 12 Months":
                    return @"
                        SELECT 
                            month, 
                            year, 
                            SUM(results) as results,
                            MAX(datetime) as datetime
                        FROM performance 
                        GROUP BY year, month
                        ORDER BY year, month
                        LIMIT 12";

                case "Quarterly - Last 8 Quarters":
                    return @"
                        SELECT 
                            QUARTER(datetime) as quarter,
                            year, 
                            SUM(results) as results,
                            MAX(datetime) as datetime
                        FROM performance 
                        GROUP BY year, QUARTER(datetime)
                        ORDER BY year, quarter
                        LIMIT 8";

                case "Yearly - All Years":
                    return @"
                        SELECT 
                            year, 
                            SUM(results) as results,
                            MAX(datetime) as datetime
                        FROM performance 
                        GROUP BY year
                        ORDER BY year";

                default:
                    return @"
                        SELECT week, month, year, results, datetime, fxid 
                        FROM performance 
                        ORDER BY year, week 
                        LIMIT 20";
            }
        }

        private string GetDataPointLabel(DataRow row, string period)
        {
            try
            {
                if (period.Contains("Weekly"))
                    return $"W{row["week"]}";
                else if (period.Contains("Monthly"))
                    return $"{GetMonthName(Convert.ToInt32(row["month"]))}";
                else if (period.Contains("Quarterly"))
                    return $"Q{row["quarter"]}";
                else if (period.Contains("Yearly"))
                    return $"{row["year"]}";
                else
                    return Convert.ToDateTime(row["datetime"]).ToString("MMM yy");
            }
            catch
            {
                return "N/A";
            }
        }

        private string GetMonthName(int month)
        {
            return new DateTime(2020, month, 1).ToString("MMM");
        }

        private void UpdateChartTitle(string period, decimal finalBalance)
        {
            chartPerformance.Titles.Clear();
            string balanceText = finalBalance >= 0 ? $"Total Profit: {finalBalance:C2}" : $"Total Loss: {finalBalance:C2}";
            var title = new Title($"Account Performance - {period.Split('-')[0].Trim()}\n{balanceText}");
            title.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            title.ForeColor = finalBalance >= 0 ? Color.DarkGreen : Color.DarkRed;
            chartPerformance.Titles.Add(title);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
                saveDialog.Title = "Save Chart As Image";
                saveDialog.FileName = $"FX_Performance_Chart_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    chartPerformance.SaveImage(saveDialog.FileName, GetImageFormat(saveDialog.FileName));
                    MessageBox.Show($"Chart exported successfully to:\n{saveDialog.FileName}", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting chart: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ChartImageFormat GetImageFormat(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName).ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return ChartImageFormat.Jpeg;
                case ".bmp":
                    return ChartImageFormat.Bmp;
                default:
                    return ChartImageFormat.Png;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auto-load data when period changes
            if (cmbPeriod.SelectedIndex >= 0)
                LoadPerformanceData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    chartPerformance.Printing.PrintDocument = printDialog.Document;
                    chartPerformance.Printing.Print(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing chart: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}