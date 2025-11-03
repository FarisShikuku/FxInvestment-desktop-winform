using FxInvestmentAdmin.Models;
using FxInvestmentAdmin.Services;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FxInvestmentAdmin.Forms
{
    public partial class PerformanceUpdateForm : Form
    {
        private PerformanceService _performanceService;
        private AccountService _accountService;

        public PerformanceUpdateForm()
        {
            InitializeComponent();
            _performanceService = new PerformanceService();
            _accountService = new AccountService();
        }

        private void PerformanceUpdateForm_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            SetDefaultValues();
            UpdateFxId();
        }

        private void LoadAccounts()
        {
            try
            {
                var accounts = _accountService.GetAllAccounts();
                cmbAccounts.Items.Clear();

                foreach (var account in accounts)
                {
                    cmbAccounts.Items.Add(new AccountItem
                    {
                        AccountId = account.AccountId,
                        DisplayText = $"{account.AccountId} - {account.AccountName} (Balance: {account.CurrentBalance:C})"
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
            // Set current date
            dtpSystemDate.Value = DateTime.Now;

            // Set current week and year
            var currentDate = DateTime.Now;
            var weekNumber = GetIso8601WeekOfYear(currentDate);

            numWeek.Value = weekNumber;
            numYear.Value = currentDate.Year;
        }

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFxId();
        }

        private void Parameters_Changed(object sender, EventArgs e)
        {
            UpdateFxId();
        }

        private void UpdateFxId()
        {
            if (cmbAccounts.SelectedItem is AccountItem account &&
                numWeek.Value > 0 && numYear.Value > 0)
            {
                // Format: AC1WK011 (Account + WK + WeekNumber + Month)
                var week = ((int)numWeek.Value).ToString("00");
                var month = DateTime.Now.Month.ToString("00");
                txtFxId.Text = $"{account.AccountId}WK{week}{month}";
            }
        }

        private void btnBrowseCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select Broker CSV File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtCsvFile.Text = openFileDialog.FileName;

                    // Auto-fill comments with filename
                    if (string.IsNullOrEmpty(txtComments.Text))
                    {
                        var fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                        txtComments.Text = $"Weekly performance from {fileName}";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var selectedAccount = (AccountItem)cmbAccounts.SelectedItem;
                int week = (int)numWeek.Value;
                int year = (int)numYear.Value;

                var performance = _performanceService.ProcessCsvFile(
                    txtCsvFile.Text,
                    txtFxId.Text,
                    week,
                    year,
                    txtComments.Text
                );

                if (performance != null)
                {
                    MessageBox.Show($"✅ Weekly performance saved successfully!\n\n" +
                                  $"FX ID: {performance.FxId}\n" +
                                  $"Account: {selectedAccount.AccountId}\n" +
                                  $"Week {performance.Week}, {performance.Year}\n" +
                                  $"Trades Processed: {performance.TotalTrades}\n" +
                                  $"Net Result: {performance.Results:C}\n\n" +
                                  $"PDF report can be generated from the Reports section.",
                                  "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving performance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool ValidateForm()
        {
            // Validate Account
            if (cmbAccounts.SelectedItem == null)
            {
                MessageBox.Show("Please select an account.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAccounts.Focus();
                return false;
            }

            // Validate Week
            if (numWeek.Value < 1 || numWeek.Value > 52)
            {
                MessageBox.Show("Please enter a valid week number (1-52).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numWeek.Focus();
                return false;
            }

            // Validate Year
            if (numYear.Value < 2020 || numYear.Value > 2030)
            {
                MessageBox.Show("Please enter a valid year (2020-2030).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numYear.Focus();
                return false;
            }

            // Validate CSV File
            if (string.IsNullOrWhiteSpace(txtCsvFile.Text))
            {
                MessageBox.Show("Please select a CSV file.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBrowseCsv.Focus();
                return false;
            }

            if (!File.Exists(txtCsvFile.Text))
            {
                MessageBox.Show("The selected CSV file does not exist.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBrowseCsv.Focus();
                return false;
            }

            // Check if performance record already exists
            var existingRecord = _performanceService.GetPerformanceByFxId(txtFxId.Text);
            if (existingRecord != null)
            {
                var result = MessageBox.Show(
                    $"A performance record already exists for {txtFxId.Text}.\n\n" +
                    $"Do you want to overwrite it?",
                    "Duplicate Record",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Helper method for ISO week number calculation
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
    }

}