using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace FxInvestmentAdmin.Services
{
    public class DatabaseService
    {
        private string connectionString = "Server=localhost;Database=FxInvestment;Uid=fxappuser;Pwd=fxpassword123;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine("Database connection successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }

        // Execute query and return DataTable
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error executing query: {ex.Message}");
                throw new Exception($"Database error: {ex.Message}", ex);
            }
            return dataTable;
        }

        // Execute query with parameters and return DataTable
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error executing query: {ex.Message}");
                throw new Exception($"Database error: {ex.Message}", ex);
            }
            return dataTable;
        }

        // Execute non-query (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error executing non-query: {ex.Message}");
                throw new Exception($"Database error: {ex.Message}", ex);
            }
        }

        // Execute non-query with parameters
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error executing non-query: {ex.Message}");
                throw new Exception($"Database error: {ex.Message}", ex);
            }
        }

        // Execute scalar query (returns single value)
        public object ExecuteScalar(string query)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error executing scalar: {ex.Message}");
                throw new Exception($"Database error: {ex.Message}", ex);
            }
        }

        // Execute scalar query with parameters
        public object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error executing scalar: {ex.Message}");
                throw new Exception($"Database error: {ex.Message}", ex);
            }
        }

        // Get performance data for graphical analysis
        public DataTable GetPerformanceData(string periodType, int limit = 12)
        {
            string query = BuildPerformanceQuery(periodType, limit);
            return ExecuteQuery(query);
        }

        private string BuildPerformanceQuery(string periodType, int limit)
        {
            switch (periodType.ToLower())
            {
                case "weekly":
                    return $@"
                        SELECT week, month, year, results, datetime, fxid 
                        FROM performance 
                        ORDER BY year DESC, week DESC 
                        LIMIT {limit}";

                case "monthly":
                    return $@"
                        SELECT 
                            month, 
                            year, 
                            SUM(results) as results,
                            MAX(datetime) as datetime
                        FROM performance 
                        GROUP BY year, month
                        ORDER BY year DESC, month DESC 
                        LIMIT {limit}";

                case "quarterly":
                    return $@"
                        SELECT 
                            QUARTER(datetime) as quarter,
                            year, 
                            SUM(results) as results,
                            MAX(datetime) as datetime
                        FROM performance 
                        GROUP BY year, QUARTER(datetime)
                        ORDER BY year DESC, quarter DESC 
                        LIMIT {limit}";

                case "yearly":
                    return @"
                        SELECT 
                            year, 
                            SUM(results) as results,
                            MAX(datetime) as datetime
                        FROM performance 
                        GROUP BY year
                        ORDER BY year";

                default:
                    return $@"
                        SELECT week, month, year, results, datetime, fxid 
                        FROM performance 
                        ORDER BY year, week 
                        LIMIT {limit}";
            }
        }

        // Get account statistics
        public DataTable GetAccountStatistics()
        {
            string query = @"
                SELECT 
                    COUNT(*) as total_accounts,
                    SUM(current_balance) as total_balance,
                    SUM(current_balance - initial_deposit) as total_profit
                FROM accounts 
                WHERE is_active = TRUE";

            return ExecuteQuery(query);
        }

        // Get recent performance records
        public DataTable GetRecentPerformance(int limit = 10)
        {
            string query = $@"
                SELECT 
                    p.fxid,
                    p.week,
                    p.month,
                    p.year,
                    p.results,
                    p.datetime,
                    p.total_trades,
                    p.total_profit,
                    a.account_name
                FROM performance p
                LEFT JOIN accounts a ON p.fxid = a.account_id
                ORDER BY p.datetime DESC
                LIMIT {limit}";

            return ExecuteQuery(query);
        }

        // Check if account exists
        public bool AccountExists(string accountId)
        {
            string query = "SELECT COUNT(*) FROM accounts WHERE account_id = @accountId";
            var parameters = new Dictionary<string, object> { { "@accountId", accountId } };
            var result = ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        // Get connection status with detailed info
        public string GetConnectionStatus()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    // Get server version and database name
                    string serverVersion = connection.ServerVersion;
                    string database = connection.Database;

                    return $"Connected to {database} (MySQL {serverVersion})";
                }
            }
            catch (Exception ex)
            {
                return $"Disconnected - {ex.Message}";
            }
        }
    }
}