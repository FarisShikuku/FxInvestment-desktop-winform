using CsvHelper;
using FxInvestmentAdmin.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FxInvestmentAdmin.Services
{
    public class PerformanceService
    {
        private readonly DatabaseService _dbService;

        public PerformanceService()
        {
            _dbService = new DatabaseService();
        }

        public PerformanceRecord ProcessCsvFile(string filePath, string accountId, int week, int year, string comments = "")
        {
            try
            {
                var trades = ParseCsvFile(filePath);

                if (trades == null || !trades.Any())
                {
                    MessageBox.Show("No trades found in the CSV file or file format is incorrect.",
                        "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                var performance = CalculatePerformance(trades, accountId, week, year, comments, filePath);

                if (performance != null)
                {
                    SavePerformanceRecord(performance);
                }

                return performance;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing CSV file: {ex.Message}",
                    "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private List<Trade> ParseCsvFile(string filePath)
        {
            var trades = new List<Trade>();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<TradeMap>();
                    trades = csv.GetRecords<Trade>().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading CSV file: {ex.Message}\n\nPlease ensure the file matches the expected format.",
                    "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return trades;
        }

        private PerformanceRecord CalculatePerformance(List<Trade> trades, string accountId, int week, int year, string comments, string filePath)
        {
            // Filter only closed trades
            var closedTrades = trades.Where(t => t.Status == "CLOSED").ToList();

            if (!closedTrades.Any())
            {
                MessageBox.Show("No closed trades found in the file.", "No Closed Trades",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var winningTrades = closedTrades.Where(t => t.IsWin).ToList();
            var losingTrades = closedTrades.Where(t => !t.IsWin).ToList();

            var performance = new PerformanceRecord
            {
                FxId = accountId,
                Week = week,
                Month = DateTime.Now.Month,
                Year = year,
                DateTime = DateTime.Now,
                Comments = comments,
                FilePath = filePath,
                TotalTrades = closedTrades.Count,
                TotalProfit = closedTrades.Sum(t => t.NetProfit),
                MaxWin = closedTrades.Any() ? closedTrades.Max(t => t.NetProfit) : 0,
                MinWin = closedTrades.Any() ? closedTrades.Min(t => t.NetProfit) : 0,
                AccountType = closedTrades.FirstOrDefault()?.AccountType ?? "CFD"
            };

            // Calculate results (net profit/loss)
            performance.Results = performance.TotalProfit;

            return performance;
        }

        private void SavePerformanceRecord(PerformanceRecord record)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO performance 
                        (fxid, account_base, week, month, year, results, datetime, comments, file_path, 
                         total_trades, total_profit, max_win, min_win, account_type) 
                        VALUES (@fxid, @account_base, @week, @month, @year, @results, @datetime, @comments, @file_path,
                                @total_trades, @total_profit, @max_win, @min_win, @account_type)";

                    command.Parameters.AddWithValue("@fxid", record.FxId);
                    command.Parameters.AddWithValue("@account_base", record.FxId.Split(new[] { "WK" }, StringSplitOptions.None)[0]);
                    command.Parameters.AddWithValue("@week", record.Week);
                    command.Parameters.AddWithValue("@month", record.Month);
                    command.Parameters.AddWithValue("@year", record.Year);
                    command.Parameters.AddWithValue("@results", record.Results);
                    command.Parameters.AddWithValue("@datetime", record.DateTime);
                    command.Parameters.AddWithValue("@comments", record.Comments ?? "");
                    command.Parameters.AddWithValue("@file_path", record.FilePath);
                    command.Parameters.AddWithValue("@total_trades", record.TotalTrades);
                    command.Parameters.AddWithValue("@total_profit", record.TotalProfit);
                    command.Parameters.AddWithValue("@max_win", record.MaxWin);
                    command.Parameters.AddWithValue("@min_win", record.MinWin);
                    command.Parameters.AddWithValue("@account_type", record.AccountType);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public List<PerformanceRecord> GetPerformanceHistory(string accountId = null)
        {
            var records = new List<PerformanceRecord>();

            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    if (string.IsNullOrEmpty(accountId))
                    {
                        command.CommandText = "SELECT * FROM performance ORDER BY year DESC, week DESC";
                    }
                    else
                    {
                        command.CommandText = "SELECT * FROM performance WHERE account_base = @account_base ORDER BY year DESC, week DESC";
                        command.Parameters.AddWithValue("@account_base", accountId);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var record = new PerformanceRecord
                            {
                                Id = reader.GetInt32("id"),
                                FxId = reader.GetString("fxid"),
                                Week = reader.GetInt32("week"),
                                Month = reader.GetInt32("month"),
                                Year = reader.GetInt32("year"),
                                Results = reader.GetDecimal("results"),
                                DateTime = reader.GetDateTime("datetime"),
                                Comments = reader.IsDBNull(reader.GetOrdinal("comments")) ? "" : reader.GetString("comments"),
                                FilePath = reader.IsDBNull(reader.GetOrdinal("file_path")) ? "" : reader.GetString("file_path"),
                                TotalTrades = reader.GetInt32("total_trades"),
                                TotalProfit = reader.GetDecimal("total_profit"),
                                MaxWin = reader.GetDecimal("max_win"),
                                MinWin = reader.GetDecimal("min_win"),
                                AccountType = reader.GetString("account_type")
                            };
                            records.Add(record);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading performance history: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return records;
        }

        public PerformanceRecord GetPerformanceByFxId(string fxId)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM performance WHERE fxid = @fxid";
                    command.Parameters.AddWithValue("@fxid", fxId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PerformanceRecord
                            {
                                Id = reader.GetInt32("id"),
                                FxId = reader.GetString("fxid"),
                                Week = reader.GetInt32("week"),
                                Month = reader.GetInt32("month"),
                                Year = reader.GetInt32("year"),
                                Results = reader.GetDecimal("results"),
                                DateTime = reader.GetDateTime("datetime"),
                                Comments = reader.IsDBNull(reader.GetOrdinal("comments")) ? "" : reader.GetString("comments"),
                                FilePath = reader.IsDBNull(reader.GetOrdinal("file_path")) ? "" : reader.GetString("file_path"),
                                TotalTrades = reader.GetInt32("total_trades"),
                                TotalProfit = reader.GetDecimal("total_profit"),
                                MaxWin = reader.GetDecimal("max_win"),
                                MinWin = reader.GetDecimal("min_win"),
                                AccountType = reader.GetString("account_type")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading performance: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public List<PerformanceRecord> GetPerformanceByAccount(string accountId)
        {
            return GetPerformanceHistory(accountId);
        }

        public List<PerformanceRecord> GetPerformanceByPeriod(int? year = null, int? month = null, int? week = null)
        {
            var records = new List<PerformanceRecord>();

            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    var whereClauses = new List<string>();
                    var parameters = new List<MySqlParameter>();

                    if (year.HasValue)
                    {
                        whereClauses.Add("year = @year");
                        parameters.Add(new MySqlParameter("@year", year.Value));
                    }

                    if (month.HasValue)
                    {
                        whereClauses.Add("month = @month");
                        parameters.Add(new MySqlParameter("@month", month.Value));
                    }

                    if (week.HasValue)
                    {
                        whereClauses.Add("week = @week");
                        parameters.Add(new MySqlParameter("@week", week.Value));
                    }

                    command.CommandText = "SELECT * FROM performance";

                    if (whereClauses.Any())
                    {
                        command.CommandText += " WHERE " + string.Join(" AND ", whereClauses);
                    }

                    command.CommandText += " ORDER BY year DESC, month DESC, week DESC";

                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var record = new PerformanceRecord
                            {
                                Id = reader.GetInt32("id"),
                                FxId = reader.GetString("fxid"),
                                Week = reader.GetInt32("week"),
                                Month = reader.GetInt32("month"),
                                Year = reader.GetInt32("year"),
                                Results = reader.GetDecimal("results"),
                                DateTime = reader.GetDateTime("datetime"),
                                Comments = reader.IsDBNull(reader.GetOrdinal("comments")) ? "" : reader.GetString("comments"),
                                FilePath = reader.IsDBNull(reader.GetOrdinal("file_path")) ? "" : reader.GetString("file_path"),
                                TotalTrades = reader.GetInt32("total_trades"),
                                TotalProfit = reader.GetDecimal("total_profit"),
                                MaxWin = reader.GetDecimal("max_win"),
                                MinWin = reader.GetDecimal("min_win"),
                                AccountType = reader.GetString("account_type")
                            };
                            records.Add(record);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading performance by period: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return records;
        }

        public bool DeletePerformanceRecord(int recordId)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM performance WHERE id = @id";
                    command.Parameters.AddWithValue("@id", recordId);

                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting performance record: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public decimal GetTotalProfitByAccount(string accountId)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT SUM(total_profit) FROM performance WHERE account_base = @account_base";
                    command.Parameters.AddWithValue("@account_base", accountId);

                    var result = command.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total profit: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int GetTotalTradesByAccount(string accountId)
        {
            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT SUM(total_trades) FROM performance WHERE account_base = @account_base";
                    command.Parameters.AddWithValue("@account_base", accountId);

                    var result = command.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total trades: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public Dictionary<string, decimal> GetMonthlySummary(int year, string accountId = null)
        {
            var summary = new Dictionary<string, decimal>();

            try
            {
                using (var connection = _dbService.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    if (string.IsNullOrEmpty(accountId))
                    {
                        command.CommandText = @"
                            SELECT month, SUM(total_profit) as monthly_profit 
                            FROM performance 
                            WHERE year = @year 
                            GROUP BY month 
                            ORDER BY month";
                    }
                    else
                    {
                        command.CommandText = @"
                            SELECT month, SUM(total_profit) as monthly_profit 
                            FROM performance 
                            WHERE year = @year AND account_base = @account_base 
                            GROUP BY month 
                            ORDER BY month";
                        command.Parameters.AddWithValue("@account_base", accountId);
                    }

                    command.Parameters.AddWithValue("@year", year);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var month = reader.GetInt32("month");
                            var profit = reader.GetDecimal("monthly_profit");
                            summary.Add(month.ToString("00"), profit);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly summary: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return summary;
        }
    }
}