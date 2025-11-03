using System;
using System.Collections.Generic;
using System.Linq;

namespace FxInvestmentAdmin.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountId { get; set; } // AC1, AC2, etc.
        public string AccountName { get; set; }
        public decimal InitialDeposit { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Calculated properties
        public decimal TotalProfit => CurrentBalance - InitialDeposit;
        public decimal ProfitPercentage => InitialDeposit > 0 ? (TotalProfit / InitialDeposit) * 100 : 0;
        public string Status => IsActive ? "Active" : "Inactive";
        public string DisplayName => $"{AccountId} - {AccountName}";

        // Constructor
        public Account()
        {
            Currency = "USD";
            IsActive = true;
            CreatedDate = DateTime.Now;
            CurrentBalance = 0;
        }

        // Method to update balance (for future transactions)
        public void UpdateBalance(decimal amount, string transactionType)
        {
            if (transactionType.ToUpper() == "DEPOSIT")
            {
                CurrentBalance += amount;
            }
            else if (transactionType.ToUpper() == "WITHDRAWAL")
            {
                if (amount <= CurrentBalance)
                {
                    CurrentBalance -= amount;
                }
                else
                {
                    throw new InvalidOperationException("Insufficient balance for withdrawal");
                }
            }
        }

        // Validation method
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(AccountId))
                return false;

            if (string.IsNullOrWhiteSpace(AccountName))
                return false;

            if (InitialDeposit < 0)
                return false;

            if (CurrentBalance < 0)
                return false;

            // Validate Account ID format (AC + number)
            if (!System.Text.RegularExpressions.Regex.IsMatch(AccountId, @"^AC\d+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                return false;

            return true;
        }

        // Method to get account summary
        public string GetSummary()
        {
            return $"{AccountId}: {AccountName} | Balance: {CurrentBalance:C} | Profit: {TotalProfit:C} ({ProfitPercentage:F2}%)";
        }

        // Override ToString for display purposes
        public override string ToString()
        {
            return DisplayName;
        }

        // Static method to validate Account ID format
        public static bool IsValidAccountId(string accountId)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(accountId, @"^AC\d+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        // Static method to generate next account ID
        public static string GenerateNextAccountId(List<Account> existingAccounts)
        {
            if (existingAccounts == null || !existingAccounts.Any())
                return "AC1";

            var maxId = existingAccounts
                .Where(a => IsValidAccountId(a.AccountId))
                .Select(a => int.Parse(a.AccountId.Substring(2))) // Remove "AC" prefix and parse number
                .DefaultIfEmpty(0)
                .Max();

            return $"AC{maxId + 1}";
        }
    }
}