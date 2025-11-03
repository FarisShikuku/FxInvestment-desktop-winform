using FxInvestmentAdmin.Services;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FxInvestmentAdmin
{
    public partial class DataManagementForm : Form
    {
        private DatabaseService _dbService;

        public DataManagementForm()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Loading data...";

                // Load Performance Data
                string performanceQuery = @"
                    SELECT id, fxid, week, month, year, results, datetime, 
                           total_trades, total_profit, max_win, min_win, comments
                    FROM performance 
                    ORDER BY datetime DESC";

                var performanceData = _dbService.ExecuteQuery(performanceQuery);
                dgvPerformance.DataSource = performanceData;

                // Load Accounts Data
                string accountsQuery = @"
                    SELECT id, account_id, account_name, initial_deposit, 
                           current_balance, currency, description, created_date, 
                           is_active, created_at
                    FROM accounts 
                    ORDER BY created_date DESC";

                var accountsData = _dbService.ExecuteQuery(accountsQuery);
                dgvAccounts.DataSource = accountsData;

                // Format columns
                FormatDataGridViews();

                lblStatus.Text = $"Loaded {performanceData.Rows.Count} performance records and {accountsData.Rows.Count} accounts";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error loading data";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void FormatDataGridViews()
        {
            // Format Performance Grid
            if (dgvPerformance.Columns.Contains("results"))
            {
                dgvPerformance.Columns["results"].DefaultCellStyle.Format = "C2";
                dgvPerformance.Columns["results"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvPerformance.Columns.Contains("total_profit"))
            {
                dgvPerformance.Columns["total_profit"].DefaultCellStyle.Format = "C2";
                dgvPerformance.Columns["total_profit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvPerformance.Columns.Contains("max_win"))
            {
                dgvPerformance.Columns["max_win"].DefaultCellStyle.Format = "C2";
                dgvPerformance.Columns["max_win"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvPerformance.Columns.Contains("min_win"))
            {
                dgvPerformance.Columns["min_win"].DefaultCellStyle.Format = "C2";
                dgvPerformance.Columns["min_win"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Format Accounts Grid
            if (dgvAccounts.Columns.Contains("initial_deposit"))
            {
                dgvAccounts.Columns["initial_deposit"].DefaultCellStyle.Format = "C2";
                dgvAccounts.Columns["initial_deposit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvAccounts.Columns.Contains("current_balance"))
            {
                dgvAccounts.Columns["current_balance"].DefaultCellStyle.Format = "C2";
                dgvAccounts.Columns["current_balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Set column headers
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            // Performance column headers
            string[] performanceHeaders = {
                "ID", "FX ID", "Week", "Month", "Year", "Results", "Date/Time",
                "Total Trades", "Total Profit", "Max Win", "Min Win", "Comments"
            };

            for (int i = 0; i < Math.Min(dgvPerformance.Columns.Count, performanceHeaders.Length); i++)
            {
                dgvPerformance.Columns[i].HeaderText = performanceHeaders[i];
            }

            // Accounts column headers
            string[] accountsHeaders = {
                "ID", "Account ID", "Account Name", "Initial Deposit", "Current Balance",
                "Currency", "Description", "Created Date", "Is Active", "Created At"
            };

            for (int i = 0; i < Math.Min(dgvAccounts.Columns.Count, accountsHeaders.Length); i++)
            {
                dgvAccounts.Columns[i].HeaderText = accountsHeaders[i];
            }
        }

        private void btnDeleteSelectedPerformance_Click(object sender, EventArgs e)
        {
            if (dgvPerformance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one performance record to delete.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete {dgvPerformance.SelectedRows.Count} selected performance record(s)?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int deletedCount = 0;
                    foreach (DataGridViewRow row in dgvPerformance.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        string deleteQuery = $"DELETE FROM performance WHERE id = {id}";
                        _dbService.ExecuteNonQuery(deleteQuery);
                        deletedCount++;
                    }

                    LoadData();
                    lblStatus.Text = $"Successfully deleted {deletedCount} performance record(s)";
                    MessageBox.Show($"Deleted {deletedCount} performance record(s) successfully.", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting performance records: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteAllPerformance_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "WARNING: This will delete ALL performance records! This action cannot be undone.\n\nAre you absolutely sure?",
                "Confirm Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string countQuery = "SELECT COUNT(*) FROM performance";
                    int recordCount = Convert.ToInt32(_dbService.ExecuteScalar(countQuery));

                    if (recordCount == 0)
                    {
                        MessageBox.Show("No performance records to delete.", "Information",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string deleteQuery = "DELETE FROM performance";
                    _dbService.ExecuteNonQuery(deleteQuery);

                    LoadData();
                    lblStatus.Text = "All performance records deleted successfully";
                    MessageBox.Show($"All {recordCount} performance records have been deleted.", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting all performance records: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteSelectedAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one account to delete.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete {dgvAccounts.SelectedRows.Count} selected account(s)?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int deletedCount = 0;
                    foreach (DataGridViewRow row in dgvAccounts.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        string accountId = row.Cells["account_id"].Value.ToString();

                        // First delete related performance records
                        string deletePerformanceQuery = $"DELETE FROM performance WHERE fxid = '{accountId}'";
                        _dbService.ExecuteNonQuery(deletePerformanceQuery);

                        // Then delete the account
                        string deleteAccountQuery = $"DELETE FROM accounts WHERE id = {id}";
                        _dbService.ExecuteNonQuery(deleteAccountQuery);

                        deletedCount++;
                    }

                    LoadData();
                    lblStatus.Text = $"Successfully deleted {deletedCount} account(s) and their performance records";
                    MessageBox.Show($"Deleted {deletedCount} account(s) and their related performance records successfully.", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting accounts: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteAllAccounts_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "WARNING: This will delete ALL accounts and ALL performance records! This action cannot be undone.\n\nAre you absolutely sure?",
                "Confirm Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // First delete all performance records
                    string deletePerformanceQuery = "DELETE FROM performance";
                    _dbService.ExecuteNonQuery(deletePerformanceQuery);

                    // Then delete all accounts
                    string deleteAccountsQuery = "DELETE FROM accounts";
                    _dbService.ExecuteNonQuery(deleteAccountsQuery);

                    LoadData();
                    lblStatus.Text = "All accounts and performance records deleted successfully";
                    MessageBox.Show("All accounts and performance records have been deleted.", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting all data: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefreshPerformance_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefreshAccounts_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh data when switching tabs
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}