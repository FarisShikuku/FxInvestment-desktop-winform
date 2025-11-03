using FxInvestmentAdmin.Models;
using FxInvestmentAdmin.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FxInvestmentAdmin.Forms
{
    public partial class AccountManagementForm : Form
    {
        private AccountService _accountService;
        private List<Account> _accounts;

        public AccountManagementForm()
        {
            InitializeComponent();
            _accountService = new AccountService();
            _accounts = new List<Account>();
        }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAccounts();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.ReadOnly = true;
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;

            // Configure columns
            dgvAccounts.Columns.Clear();

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "AccountId",
                HeaderText = "Account ID",
                Width = 80
            });

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "AccountName",
                HeaderText = "Account Name",
                Width = 150
            });

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "InitialDeposit",
                HeaderText = "Initial Deposit",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CurrentBalance",
                HeaderText = "Current Balance",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalProfit",
                HeaderText = "Total Profit",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProfitPercentage",
                HeaderText = "Profit %",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "F2" }
            });

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Currency",
                HeaderText = "Currency",
                Width = 70
            });

            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CreatedDate",
                HeaderText = "Created Date",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "yyyy-MM-dd" }
            });
        }

        private void LoadAccounts()
        {
            try
            {
                _accounts = _accountService.GetAllAccounts();
                dgvAccounts.DataSource = _accounts;
                UpdateSummaryPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummaryPanel()
        {
            if (_accounts.Count == 0)
            {
                lblTotalAccounts.Text = "Total Accounts: 0";
                lblTotalBalance.Text = "Total Balance: $0.00";
                lblTotalProfit.Text = "Total Profit: $0.00";
                return;
            }

            lblTotalAccounts.Text = $"Total Accounts: {_accounts.Count}";

            decimal totalBalance = _accounts.Sum(a => a.CurrentBalance);
            lblTotalBalance.Text = $"Total Balance: {totalBalance:C}";

            decimal totalProfit = _accounts.Sum(a => a.TotalProfit);
            lblTotalProfit.Text = $"Total Profit: {totalProfit:C}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var account = new Account
                {
                    AccountId = txtAccountId.Text.Trim().ToUpper(),
                    AccountName = txtAccountName.Text.Trim(),
                    InitialDeposit = numInitialDeposit.Value,
                    Currency = cmbCurrency.SelectedItem?.ToString() ?? "USD",
                    Description = txtDescription.Text.Trim(),
                    CreatedDate = dtpCreatedDate.Value.Date
                };

                if (_accountService.CreateAccount(account))
                {
                    MessageBox.Show("Account created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadAccounts();
                    tabControlMain.SelectedTab = tabPageView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            // Validate Account ID
            if (string.IsNullOrWhiteSpace(txtAccountId.Text))
            {
                ShowError("Please enter Account ID", txtAccountId);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAccountId.Text, @"^AC\d+$"))
            {
                ShowError("Account ID must be in format AC followed by number (e.g., AC1, AC2)", txtAccountId);
                return false;
            }

            if (_accountService.IsAccountIdExists(txtAccountId.Text))
            {
                ShowError("Account ID already exists. Please use a different ID.", txtAccountId);
                return false;
            }

            // Validate Account Name
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                ShowError("Please enter Account Name", txtAccountName);
                return false;
            }

            // Validate Initial Deposit
            if (numInitialDeposit.Value <= 0)
            {
                ShowError("Please enter a valid initial deposit amount", numInitialDeposit);
                return false;
            }

            return true;
        }

        private void ShowError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void ClearForm()
        {
            txtAccountId.Clear();
            txtAccountName.Clear();
            numInitialDeposit.Value = 1000;
            cmbCurrency.SelectedIndex = 0;
            txtDescription.Clear();
            dtpCreatedDate.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateId_Click(object sender, EventArgs e)
        {
            var accounts = _accountService.GetAllAccounts();
            if (accounts.Count == 0)
            {
                txtAccountId.Text = "AC1";
                return;
            }

            var maxId = accounts
                .Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.AccountId, @"^AC\d+$"))
                .Select(a => int.Parse(a.AccountId.Substring(2)))
                .DefaultIfEmpty(0)
                .Max();

            txtAccountId.Text = $"AC{maxId + 1}";
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            // Optional: Show account details when selected
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }
    }
}