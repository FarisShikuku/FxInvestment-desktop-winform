using FxInvestmentAdmin.Models;
using FxInvestmentAdmin.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FxInvestmentAdmin.Forms
{
    public partial class ReportsDashboardForm : Form
    {
        private PerformanceService _performanceService;
        private AccountService _accountService;
        private PdfReportService _pdfReportService;

        public ReportsDashboardForm()
        {
            InitializeComponent();
            _performanceService = new PerformanceService();
            _accountService = new AccountService();
            _pdfReportService = new PdfReportService();
        }

        private void ReportsDashboardForm_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            SetDefaultValues();
            SetupPerformanceGrid();
            cmbReportType.SelectedIndex = 0; // Select Weekly by default
        }

        private void LoadAccounts()
        {
            try
            {
                var accounts = _accountService.GetAllAccounts();
                cmbAccounts.Items.Clear();

                // Add "All Accounts" option
                cmbAccounts.Items.Add("All Accounts");

                foreach (var account in accounts)
                {
                    cmbAccounts.Items.Add(new AccountItem
                    {
                        AccountId = account.AccountId,
                        DisplayText = $"{account.AccountId} - {account.AccountName}"
                    });
                }

                if (cmbAccounts.Items.Count > 0)
                    cmbAccounts.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultValues()
        {
            var currentDate = DateTime.Now;

            // Set current week and year
            numWeek.Value = GetIso8601WeekOfYear(currentDate);
            numWeeklyYear.Value = currentDate.Year;

            // Set current month and year
            numMonth.Value = currentDate.Month;
            numMonthlyYear.Value = currentDate.Year;

            // Set current quarter and year
            numQuarter.Value = GetCurrentQuarter(currentDate);
            numQuarterlyYear.Value = currentDate.Year;
        }

        private void SetupPerformanceGrid()
        {
            dgvPerformance.AutoGenerateColumns = false;
            dgvPerformance.Columns.Clear();

            dgvPerformance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FxId",
                HeaderText = "FX ID",
                Width = 120
            });

            dgvPerformance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Week",
                HeaderText = "Week",
                Width = 60
            });

            dgvPerformance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Year",
                HeaderText = "Year",
                Width = 80
            });

            dgvPerformance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalTrades",
                HeaderText = "Trades",
                Width = 70
            });

            dgvPerformance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalProfit",
                HeaderText = "Profit/Loss",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            dgvPerformance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Results",
                HeaderText = "Net Results",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            dgvPerformance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DateTime",
                HeaderText = "Report Date",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "yyyy-MM-dd" }
            });
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide all parameter panels first
            panelWeeklyParams.Visible = false;
            panelMonthlyParams.Visible = false;
            panelQuarterlyParams.Visible = false;

            // Show the appropriate panel based on selection
            switch (cmbReportType.SelectedIndex)
            {
                case 0: // Weekly
                    panelWeeklyParams.Visible = true;
                    break;
                case 1: // Monthly
                    panelMonthlyParams.Visible = true;
                    break;
                case 2: // Quarterly
                    panelQuarterlyParams.Visible = true;
                    break;
            }

            // Refresh the performance data
            LoadPerformanceData();
        }

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPerformanceData();
        }

        private void LoadPerformanceData()
        {
            try
            {
                List<PerformanceRecord> performances;

                if (cmbAccounts.SelectedItem is string && cmbAccounts.SelectedItem.ToString() == "All Accounts")
                {
                    // Load all performances
                    performances = _performanceService.GetPerformanceHistory();
                }
                else if (cmbAccounts.SelectedItem is AccountItem accountItem)
                {
                    // Load performances for specific account
                    performances = _performanceService.GetPerformanceByAccount(accountItem.AccountId);
                }
                else
                {
                    performances = new List<PerformanceRecord>();
                }

                dgvPerformance.DataSource = performances;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading performance data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeneratePdf_Click(object sender, EventArgs e)
        {
            if (cmbAccounts.SelectedItem == null)
            {
                MessageBox.Show("Please select an account.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string accountId = GetSelectedAccountId();
                if (string.IsNullOrEmpty(accountId))
                    return;

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveDialog.FileName = GeneratePdfFileName(accountId);

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        switch (cmbReportType.SelectedIndex)
                        {
                            case 0: // Weekly
                                GenerateWeeklyPdf(accountId, saveDialog.FileName);
                                break;
                            case 1: // Monthly
                                GenerateMonthlyPdf(accountId, saveDialog.FileName);
                                break;
                            case 2: // Quarterly
                                GenerateQuarterlyPdf(accountId, saveDialog.FileName);
                                break;
                        }

                        MessageBox.Show($"PDF report generated successfully!\n\n{saveDialog.FileName}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            if (cmbAccounts.SelectedItem == null)
            {
                MessageBox.Show("Please select an account.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string accountId = GetSelectedAccountId();
                if (string.IsNullOrEmpty(accountId))
                    return;

                var performances = _performanceService.GetPerformanceByAccount(accountId);

                if (!performances.Any())
                {
                    MessageBox.Show("No performance data found for the selected account.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var totalProfit = performances.Sum(p => p.TotalProfit);
                var totalTrades = performances.Sum(p => p.TotalTrades);
                var avgProfit = performances.Average(p => p.TotalProfit);
                var profitableWeeks = performances.Count(p => p.TotalProfit > 0);
                var winRate = (double)profitableWeeks / performances.Count * 100;

                MessageBox.Show(
                    $"Account Summary: {accountId}\n\n" +
                    $"Total Reports: {performances.Count}\n" +
                    $"Total Trades: {totalTrades}\n" +
                    $"Total Profit/Loss: {totalProfit:C}\n" +
                    $"Average Weekly: {avgProfit:C}\n" +
                    $"Win Rate: {winRate:F1}% ({profitableWeeks}/{performances.Count} weeks)",
                    "Performance Summary",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating summary: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedAccountId()
        {
            if (cmbAccounts.SelectedItem is string && cmbAccounts.SelectedItem.ToString() == "All Accounts")
            {
                MessageBox.Show("Please select a specific account (not 'All Accounts') for PDF generation.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (cmbAccounts.SelectedItem is AccountItem accountItem)
            {
                return accountItem.AccountId;
            }

            return null;
        }

        private void GenerateWeeklyPdf(string accountId, string filePath)
        {
            int week = (int)numWeek.Value;
            int year = (int)numWeeklyYear.Value;

            var fxId = $"{accountId}WK{week:00}{DateTime.Now.Month:00}";
            var performance = _performanceService.GetPerformanceByFxId(fxId);

            if (performance == null)
            {
                MessageBox.Show($"No performance data found for {fxId}", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _pdfReportService.GenerateWeeklyPerformanceReport(performance, filePath);
        }

        private void GenerateMonthlyPdf(string accountId, string filePath)
        {
            int month = (int)numMonth.Value;
            int year = (int)numMonthlyYear.Value;

            _pdfReportService.GenerateMonthlyReport(accountId, month, year, filePath);
        }

        private void GenerateQuarterlyPdf(string accountId, string filePath)
        {
            int quarter = (int)numQuarter.Value;
            int year = (int)numQuarterlyYear.Value;

            _pdfReportService.GenerateQuarterlyReport(accountId, quarter, year, filePath);
        }

        private string GeneratePdfFileName(string accountId)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var reportType = cmbReportType.SelectedItem.ToString().Replace(" ", "").ToLower();
            return $"{accountId}_{reportType}_{timestamp}.pdf";
        }

        // Helper methods
        private int GetIso8601WeekOfYear(DateTime time)
        {
            var day = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                time, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private int GetCurrentQuarter(DateTime date)
        {
            return (date.Month - 1) / 3 + 1;
        }
    }

    // Helper class for account combobox
    public class AccountItem
    {
        public string AccountId { get; set; }
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}