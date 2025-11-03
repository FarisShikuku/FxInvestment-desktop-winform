using iTextSharp.text;
using iTextSharp.text.pdf;
using FxInvestmentAdmin.Models;
using FxInvestmentAdmin.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FxInvestmentAdmin.Services
{
    public class PdfReportService
    {
        private readonly PerformanceService _performanceService;
        private readonly AccountService _accountService;

        public PdfReportService()
        {
            _performanceService = new PerformanceService();
            _accountService = new AccountService();
        }

        public void GenerateWeeklyPerformanceReport(PerformanceRecord performance, string outputPath)
        {
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            try
            {
                PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
                document.Open();

                // Add title and header
                AddHeader(document, $"WEEKLY PERFORMANCE REPORT - {performance.FxId}");

                // Performance summary section
                AddSectionTitle(document, "Performance Summary");
                AddPerformanceSummaryTable(document, performance);

                // Trading statistics section
                AddSectionTitle(document, "Trading Statistics");
                AddTradingStatistics(document, performance);

                // Account information section
                var account = _accountService.GetAccountById(performance.FxId.Split(new[] { "WK" }, StringSplitOptions.None)[0]);
                if (account != null)
                {
                    AddSectionTitle(document, "Account Information");
                    AddAccountInfo(document, account, performance);
                }

                // Comments section
                if (!string.IsNullOrEmpty(performance.Comments))
                {
                    AddSectionTitle(document, "Comments & Analysis");
                    AddCommentsSection(document, performance.Comments);
                }

                // Footer
                AddFooter(document);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "PDF Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document.Close();
            }
        }

        public void GenerateMonthlyReport(string accountId, int month, int year, string outputPath)
        {
            var performances = _performanceService.GetPerformanceByPeriod(year, month)
                .Where(p => p.FxId.StartsWith(accountId))
                .ToList();

            if (!performances.Any())
            {
                MessageBox.Show("No performance data found for the selected period.", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            try
            {
                PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
                document.Open();

                AddHeader(document, $"MONTHLY PERFORMANCE REPORT - {accountId} ({month:00}/{year})");

                // Monthly summary
                AddSectionTitle(document, "Monthly Summary");
                AddMonthlySummaryTable(document, performances, accountId, month, year);

                // Weekly breakdown
                AddSectionTitle(document, "Weekly Breakdown");
                AddWeeklyBreakdownTable(document, performances);

                // Performance chart description
                AddSectionTitle(document, "Performance Analysis");
                AddMonthlyAnalysis(document, performances);

                AddFooter(document);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating monthly PDF: {ex.Message}", "PDF Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document.Close();
            }
        }

        public void GenerateQuarterlyReport(string accountId, int quarter, int year, string outputPath)
        {
            var months = GetMonthsInQuarter(quarter);
            var performances = new List<PerformanceRecord>();

            foreach (var month in months)
            {
                var monthlyData = _performanceService.GetPerformanceByPeriod(year, month)
                    .Where(p => p.FxId.StartsWith(accountId))
                    .ToList();
                performances.AddRange(monthlyData);
            }

            if (!performances.Any())
            {
                MessageBox.Show("No performance data found for the selected quarter.", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            try
            {
                PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
                document.Open();

                AddHeader(document, $"QUARTERLY PERFORMANCE REPORT - {accountId} (Q{quarter} {year})");

                // Quarterly summary
                AddSectionTitle(document, "Quarterly Summary");
                AddQuarterlySummaryTable(document, performances, accountId, quarter, year);

                // Monthly breakdown
                AddSectionTitle(document, "Monthly Breakdown");
                AddMonthlyBreakdownTable(document, performances, quarter, year);

                // Performance trends
                AddSectionTitle(document, "Performance Trends");
                AddQuarterlyAnalysis(document, performances);

                AddFooter(document);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating quarterly PDF: {ex.Message}", "PDF Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document.Close();
            }
        }

        // ADD MISSING METHOD
        private void AddQuarterlySummaryTable(Document document, List<PerformanceRecord> performances, string accountId, int quarter, int year)
        {
            var totalTrades = performances.Sum(p => p.TotalTrades);
            var totalProfit = performances.Sum(p => p.TotalProfit);
            var avgMonthlyProfit = performances.GroupBy(p => p.Month).Average(g => g.Sum(p => p.TotalProfit));
            var bestMonth = performances.GroupBy(p => p.Month)
                                      .Select(g => new { Month = g.Key, Profit = g.Sum(p => p.TotalProfit) })
                                      .OrderByDescending(x => x.Profit)
                                      .FirstOrDefault();

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SpacingAfter = 15f;

            AddTableHeaderCell(table, "Quarterly Metric");
            AddTableHeaderCell(table, "Value");

            AddTableCell(table, "Account", accountId);
            AddTableCell(table, "Period", $"Q{quarter} {year}");
            AddTableCell(table, "Months Reported", performances.GroupBy(p => p.Month).Count().ToString());
            AddTableCell(table, "Total Trades", totalTrades.ToString());
            AddTableCell(table, "Quarterly Profit/Loss", totalProfit.ToString("C"));
            AddTableCell(table, "Average Monthly Profit", avgMonthlyProfit.ToString("C"));
            AddTableCell(table, "Best Month", bestMonth != null ? $"{bestMonth.Month:00} ({bestMonth.Profit:C})" : "N/A");
            AddTableCell(table, "Consistency", CalculateQuarterlyConsistency(performances));

            document.Add(table);
        }

        private string CalculateQuarterlyConsistency(List<PerformanceRecord> performances)
        {
            var monthlyProfits = performances.GroupBy(p => p.Month)
                                           .Select(g => g.Sum(p => p.TotalProfit))
                                           .ToList();

            if (monthlyProfits.Count < 2) return "N/A";

            var profitableMonths = monthlyProfits.Count(p => p > 0);
            return $"{profitableMonths}/{monthlyProfits.Count} profitable months";
        }

        private void AddHeader(Document document, string title)
        {
            // Replace all occurrences of BaseColor.GRAY with BaseColor.Gray
            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.Gray);
            var titleParagraph = new Paragraph(title, titleFont);
            titleParagraph.Alignment = Element.ALIGN_CENTER;
            titleParagraph.SpacingAfter = 20f;
            document.Add(titleParagraph);

            // ...
            var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.Gray);
            var dateParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", dateFont);
            dateParagraph.Alignment = Element.ALIGN_RIGHT;
            dateParagraph.SpacingAfter = 15f;
            document.Add(dateParagraph);
        }

        private void AddSectionTitle(Document document, string title)
        {
            // ...
            var font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.Gray);
            var paragraph = new Paragraph(title, font);
            paragraph.SpacingBefore = 15f;
            paragraph.SpacingAfter = 10f;
            document.Add(paragraph);
        }

        private void AddPerformanceSummaryTable(Document document, PerformanceRecord performance)
        {
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SpacingAfter = 15f;

            AddTableHeaderCell(table, "Metric");
            AddTableHeaderCell(table, "Value");

            AddTableCell(table, "FX ID", performance.FxId);
            AddTableCell(table, "Week", $"Week {performance.Week}, {performance.Year}");
            AddTableCell(table, "Report Date", performance.DateTime.ToString("yyyy-MM-dd"));
            AddTableCell(table, "Total Trades", performance.TotalTrades.ToString());
            AddTableCell(table, "Total Profit/Loss", performance.TotalProfit.ToString("C"));
            AddTableCell(table, "Net Results", performance.Results.ToString("C"));
            AddTableCell(table, "Maximum Win", performance.MaxWin.ToString("C"));
            AddTableCell(table, "Minimum Win", performance.MinWin.ToString("C"));

            // FIX: Convert to decimal before multiplication
            decimal avgPerTrade = performance.TotalTrades > 0 ? performance.TotalProfit / performance.TotalTrades : 0;
            AddTableCell(table, "Average per Trade", avgPerTrade.ToString("C"));

            // FIX: Use decimal for win rate calculation
            decimal winRate = performance.TotalTrades > 0 ? (100m / performance.TotalTrades) * performance.TotalTrades : 0;
            AddTableCell(table, "Win Rate", $"{winRate:F1}%");

            document.Add(table);
        }

        private void AddTradingStatistics(Document document, PerformanceRecord performance)
        {
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SpacingAfter = 15f;

            AddTableHeaderCell(table, "Statistic");
            AddTableHeaderCell(table, "Value");

            AddTableCell(table, "Trading Period", "Weekly");
            AddTableCell(table, "Account Type", performance.AccountType);
            AddTableCell(table, "Performance Score", CalculatePerformanceScore(performance).ToString("F1"));
            AddTableCell(table, "Risk Assessment", AssessRisk(performance));
            AddTableCell(table, "Recommendation", GetRecommendation(performance));

            document.Add(table);
        }

        private void AddAccountInfo(Document document, Account account, PerformanceRecord performance)
        {
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SpacingAfter = 15f;

            AddTableHeaderCell(table, "Account Detail");
            AddTableHeaderCell(table, "Value");

            AddTableCell(table, "Account ID", account.AccountId);
            AddTableCell(table, "Account Name", account.AccountName);
            AddTableCell(table, "Initial Deposit", account.InitialDeposit.ToString("C"));
            AddTableCell(table, "Current Balance", account.CurrentBalance.ToString("C"));
            AddTableCell(table, "Total Profit/Loss", account.TotalProfit.ToString("C"));
            AddTableCell(table, "Return Percentage", $"{account.ProfitPercentage:F2}%");
            AddTableCell(table, "Currency", account.Currency);

            document.Add(table);
        }

        private void AddMonthlySummaryTable(Document document, List<PerformanceRecord> performances, string accountId, int month, int year)
        {
            var totalTrades = performances.Sum(p => p.TotalTrades);
            var totalProfit = performances.Sum(p => p.TotalProfit);
            var avgWeeklyProfit = performances.Average(p => p.TotalProfit);
            var bestWeek = performances.OrderByDescending(p => p.TotalProfit).FirstOrDefault();
            var worstWeek = performances.OrderBy(p => p.TotalProfit).FirstOrDefault();

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SpacingAfter = 15f;

            AddTableHeaderCell(table, "Monthly Metric");
            AddTableHeaderCell(table, "Value");

            AddTableCell(table, "Account", accountId);
            AddTableCell(table, "Period", $"{month:00}/{year}");
            AddTableCell(table, "Weeks Reported", performances.Count.ToString());
            AddTableCell(table, "Total Trades", totalTrades.ToString());
            AddTableCell(table, "Monthly Profit/Loss", totalProfit.ToString("C"));
            AddTableCell(table, "Average Weekly Profit", avgWeeklyProfit.ToString("C"));
            AddTableCell(table, "Best Week", bestWeek != null ? $"{bestWeek.FxId} ({bestWeek.TotalProfit:C})" : "N/A");
            AddTableCell(table, "Worst Week", worstWeek != null ? $"{worstWeek.FxId} ({worstWeek.TotalProfit:C})" : "N/A");
            AddTableCell(table, "Consistency Score", CalculateConsistencyScore(performances).ToString("F1"));

            document.Add(table);
        }

        private void AddWeeklyBreakdownTable(Document document, List<PerformanceRecord> performances)
        {
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;
            table.SpacingAfter = 15f;

            AddTableHeaderCell(table, "Week");
            AddTableHeaderCell(table, "FX ID");
            AddTableHeaderCell(table, "Trades");
            AddTableHeaderCell(table, "Profit/Loss");
            AddTableHeaderCell(table, "Status");

            foreach (var performance in performances.OrderBy(p => p.Week))
            {
                table.AddCell(performance.Week.ToString());
                table.AddCell(performance.FxId);
                table.AddCell(performance.TotalTrades.ToString());
                table.AddCell(performance.TotalProfit.ToString("C"));
                table.AddCell(performance.TotalProfit >= 0 ? "Profit" : "Loss");
            }

            document.Add(table);
        }

        private void AddMonthlyBreakdownTable(Document document, List<PerformanceRecord> performances, int quarter, int year)
        {
            var monthlyGroups = performances.GroupBy(p => p.Month)
                                          .Select(g => new { Month = g.Key, Profit = g.Sum(p => p.TotalProfit), Trades = g.Sum(p => p.TotalTrades) })
                                          .OrderBy(x => x.Month);

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SpacingAfter = 15f;

            AddTableHeaderCell(table, "Month");
            AddTableHeaderCell(table, "Weeks");
            AddTableHeaderCell(table, "Trades");
            AddTableHeaderCell(table, "Monthly Profit/Loss");

            foreach (var month in monthlyGroups)
            {
                table.AddCell(month.Month.ToString("00"));
                table.AddCell(performances.Count(p => p.Month == month.Month).ToString());
                table.AddCell(month.Trades.ToString());
                table.AddCell(month.Profit.ToString("C"));
            }

            document.Add(table);
        }

        private void AddCommentsSection(Document document, string comments)
        {
            // Use BaseColor.BLACK (this should work in iTextSharp)
            var font = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.Black);
            var paragraph = new Paragraph(comments, font);
            paragraph.SpacingAfter = 15f;
            document.Add(paragraph);
        }

        private void AddMonthlyAnalysis(Document document, List<PerformanceRecord> performances)
        {
            var analysis = GenerateMonthlyAnalysis(performances);
            // Use BaseColor.BLACK
            var font = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.Black);
            var paragraph = new Paragraph(analysis, font);
            paragraph.SpacingAfter = 15f;
            document.Add(paragraph);
        }

        private void AddQuarterlyAnalysis(Document document, List<PerformanceRecord> performances)
        {
            var analysis = GenerateQuarterlyAnalysis(performances);
            // Use BaseColor.BLACK
            var font = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.Black);
            var paragraph = new Paragraph(analysis, font);
            paragraph.SpacingAfter = 15f;
            document.Add(paragraph);
        }

        private void AddFooter(Document document)
        {
            // Use BaseColor.GRAY
            var font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.Gray);
            var footer = new Paragraph("Generated by FxInvestment Admin System - Confidential", font);
            footer.Alignment = Element.ALIGN_CENTER;
            footer.SpacingBefore = 20f;
            document.Add(footer);
        }

        // Helper methods
        private void AddTableHeaderCell(PdfPTable table, string text)
        {
            // Use BaseColor.LIGHT_GRAY (this should work)
            var cell = new PdfPCell(new Phrase(text, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
            cell.BackgroundColor = BaseColor.LightGray;
            cell.Padding = 5f;
            table.AddCell(cell);
        }

        private void AddTableCell(PdfPTable table, string label, string value)
        {
            table.AddCell(new PdfPCell(new Phrase(label, FontFactory.GetFont(FontFactory.HELVETICA, 9))) { Padding = 4f });
            table.AddCell(new PdfPCell(new Phrase(value, FontFactory.GetFont(FontFactory.HELVETICA, 9))) { Padding = 4f });
        }

        private double CalculatePerformanceScore(PerformanceRecord performance)
        {
            // Simple scoring algorithm
            double score = 0;
            if (performance.TotalProfit > 0) score += 50;
            if (performance.TotalTrades >= 5) score += 20;
            if (performance.MaxWin > performance.TotalProfit * 0.5m) score += 15;
            if (performance.TotalTrades > 0 && (performance.TotalProfit / performance.TotalTrades) > 0) score += 15;
            return Math.Min(score, 100);
        }

        private string AssessRisk(PerformanceRecord performance)
        {
            if (performance.TotalProfit < 0) return "High Risk";
            if (performance.MaxWin > performance.TotalProfit * 2) return "Medium Risk";
            return "Low Risk";
        }

        private string GetRecommendation(PerformanceRecord performance)
        {
            if (performance.TotalProfit < 0) return "Review strategy and risk management";
            if (performance.TotalProfit > 0 && performance.TotalTrades < 3) return "Consider increasing trade frequency";
            return "Continue current strategy";
        }

        private double CalculateConsistencyScore(List<PerformanceRecord> performances)
        {
            if (performances.Count < 2) return 100;
            var profits = performances.Select(p => (double)p.TotalProfit).ToArray();
            var avg = profits.Average();
            var stdDev = Math.Sqrt(profits.Average(v => Math.Pow(v - avg, 2)));
            return Math.Max(0, 100 - (stdDev / Math.Abs(avg)) * 50);
        }

        private string GenerateMonthlyAnalysis(List<PerformanceRecord> performances)
        {
            var totalProfit = performances.Sum(p => p.TotalProfit);
            var avgProfit = performances.Average(p => p.TotalProfit);
            var profitableWeeks = performances.Count(p => p.TotalProfit > 0);
            var consistency = (double)profitableWeeks / performances.Count * 100;

            return $"Monthly Analysis: The account showed {(totalProfit >= 0 ? "positive" : "negative")} performance with {profitableWeeks} profitable weeks out of {performances.Count} ({consistency:F1}% consistency). " +
                   $"Average weekly profit was {avgProfit:C}. {(totalProfit >= 0 ? "Consider maintaining the current strategy." : "Review trading approach and risk management.")}";
        }

        private string GenerateQuarterlyAnalysis(List<PerformanceRecord> performances)
        {
            var totalProfit = performances.Sum(p => p.TotalProfit);
            var monthlyProfits = performances.GroupBy(p => p.Month)
                                           .Select(g => g.Sum(p => p.TotalProfit))
                                           .ToList();
            var trend = monthlyProfits.Count > 1 ? (monthlyProfits.Last() > monthlyProfits.First() ? "improving" : "declining") : "stable";

            return $"Quarterly Analysis: Overall {(totalProfit >= 0 ? "profitable" : "unprofitable")} quarter with a {trend} trend. " +
                   $"Total quarterly performance: {totalProfit:C}. " +
                   $"Recommendation: {(totalProfit >= 0 ? "Consider scaling positions gradually." : "Focus on risk management and strategy refinement.")}";
        }

        private int[] GetMonthsInQuarter(int quarter)
        {
            switch (quarter)
            {
                case 1: return new int[] { 1, 2, 3 };
                case 2: return new int[] { 4, 5, 6 };
                case 3: return new int[] { 7, 8, 9 };
                case 4: return new int[] { 10, 11, 12 };
                default: return new int[] { };
            }
        }
    }
}