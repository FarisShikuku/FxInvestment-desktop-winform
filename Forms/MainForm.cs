using FxInvestmentAdmin.Forms;
using FxInvestmentAdmin.Models;
using FxInvestmentAdmin.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FxInvestmentAdmin
{
    public partial class MainForm : Form
    {
        private AccountService _accountService;
        private PerformanceService _performanceService;
        private DatabaseService _dbService;

        public MainForm()
        {
            InitializeComponent();
            _accountService = new AccountService();
            _performanceService = new PerformanceService();
            _dbService = new DatabaseService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeApplication();
            LoadDashboardData();
            UpdateConnectionStatus();
        }

        private void InitializeApplication()
        {
            // Set form properties
            this.WindowState = FormWindowState.Maximized;

            // Update status
            lblStatus.Text = "Initializing...";
            lblStatus.ForeColor = Color.Orange;
        }

        private void LoadDashboardData()
        {
            try
            {
                // Load accounts and performance data
                var accounts = _accountService.GetAllAccounts();
                var recentPerformance = _performanceService.GetPerformanceHistory();

                // Update quick stats
                UpdateQuickStats(accounts);

                // Update recent activity
                UpdateRecentActivity(recentPerformance);

                // Update status
                lblStatus.Text = "Ready";
                lblStatus.ForeColor = Color.Green;

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading data";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQuickStats(List<Account> accounts)
        {
            // Total Accounts
            lblStat1Value.Text = accounts.Count.ToString();

            // Total Balance
            decimal totalBalance = 0;
            foreach (var account in accounts)
            {
                totalBalance += account.CurrentBalance;
            }
            lblStat2Value.Text = totalBalance.ToString("C");

            // Total Profit
            decimal totalProfit = 0;
            foreach (var account in accounts)
            {
                totalProfit += account.TotalProfit;
            }
            lblStat3Value.Text = totalProfit.ToString("C");

            // Color code profit (green for positive, red for negative)
            if (totalProfit >= 0)
            {
                lblStat3Value.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblStat3Value.ForeColor = Color.Red;
            }
        }

        private void UpdateRecentActivity(List<PerformanceRecord> performances)
        {
            lstRecentActivity.Items.Clear();

            if (performances == null || performances.Count == 0)
            {
                lstRecentActivity.Items.Add("No recent activity found.");
                return;
            }

            // Show latest 10 activities
            var recentActivities = performances
                .OrderByDescending(p => p.DateTime)
                .Take(10)
                .ToList();

            foreach (var performance in recentActivities)
            {
                string status = performance.TotalProfit >= 0 ? "Profit" : "Loss";
                string profitColor = performance.TotalProfit >= 0 ? "[+]" : "[-]";

                string activity = $"{performance.DateTime:MM/dd/yyyy} - {performance.FxId} - " +
                                $"{profitColor} {Math.Abs(performance.TotalProfit):C} - " +
                                $"{performance.TotalTrades} trades";

                lstRecentActivity.Items.Add(activity);
            }
        }

        private void UpdateConnectionStatus()
        {
            bool isConnected = _dbService.TestConnection();
            if (isConnected)
            {
                lblStatus.Text = "Database Connected";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Database Disconnected";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            OpenForm(new PerformanceUpdateForm());
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            OpenForm(new AccountManagementForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenForm(new ReportsDashboardForm());
        }
        private void btnDataManagement_Click(object sender, EventArgs e)
        {
            DataManagementForm dataForm = new DataManagementForm();
            dataForm.ShowDialog();

            // Refresh dashboard after data management
            LoadDashboardData();
        }
        // Add this method to MainForm
        private void btnGraphicalAnalysis_Click(object sender, EventArgs e)
        {
            GraphicalAnalysisForm graphForm = new GraphicalAnalysisForm();
            graphForm.ShowDialog();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit FX Investment Admin?",
                "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void OpenForm(Form form)
        {
            try
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();

                // Refresh dashboard data when child form closes
                LoadDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to refresh dashboard from other forms
        public void RefreshDashboard()
        {
            LoadDashboardData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Are you sure you want to exit FX Investment Admin?",
                    "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}