using FxInvestmentAdmin.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FxInvestmentAdmin.Services
{
    public class AccountService
    {
        private readonly DatabaseService _dbService;

        public AccountService()
        {
            _dbService = new DatabaseService();
        }

        public bool CreateAccount(Account account)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO accounts 
                        (account_id, account_name, initial_deposit, current_balance, currency, description, created_date, is_active) 
                        VALUES (@account_id, @account_name, @initial_deposit, @current_balance, @currency, @description, @created_date, @is_active)";

                    command.Parameters.AddWithValue("@account_id", account.AccountId.ToUpper());
                    command.Parameters.AddWithValue("@account_name", account.AccountName);
                    command.Parameters.AddWithValue("@initial_deposit", account.InitialDeposit);
                    command.Parameters.AddWithValue("@current_balance", account.InitialDeposit); // Start with initial deposit
                    command.Parameters.AddWithValue("@currency", account.Currency);
                    command.Parameters.AddWithValue("@description", account.Description);
                    command.Parameters.AddWithValue("@created_date", account.CreatedDate);
                    command.Parameters.AddWithValue("@is_active", account.IsActive);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Account> GetAllAccounts()
        {
            var accounts = new List<Account>();

            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM accounts WHERE is_active = TRUE ORDER BY account_id";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var account = new Account
                            {
                                Id = reader.GetInt32("id"),
                                AccountId = reader.GetString("account_id"),
                                AccountName = reader.GetString("account_name"),
                                InitialDeposit = reader.GetDecimal("initial_deposit"),
                                CurrentBalance = reader.GetDecimal("current_balance"),
                                Currency = reader.GetString("currency"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString("description"),
                                CreatedDate = reader.GetDateTime("created_date"),
                                IsActive = reader.GetBoolean("is_active"),
                                CreatedAt = reader.GetDateTime("created_at")
                            };
                            accounts.Add(account);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return accounts;
        }

        public Account GetAccountById(string accountId)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM accounts WHERE account_id = @account_id AND is_active = TRUE";
                    command.Parameters.AddWithValue("@account_id", accountId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Account
                            {
                                Id = reader.GetInt32("id"),
                                AccountId = reader.GetString("account_id"),
                                AccountName = reader.GetString("account_name"),
                                InitialDeposit = reader.GetDecimal("initial_deposit"),
                                CurrentBalance = reader.GetDecimal("current_balance"),
                                Currency = reader.GetString("currency"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString("description"),
                                CreatedDate = reader.GetDateTime("created_date"),
                                IsActive = reader.GetBoolean("is_active"),
                                CreatedAt = reader.GetDateTime("created_at")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading account: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool IsAccountIdExists(string accountId)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT COUNT(*) FROM accounts WHERE account_id = @account_id";
                    command.Parameters.AddWithValue("@account_id", accountId.ToUpper());

                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking account: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}