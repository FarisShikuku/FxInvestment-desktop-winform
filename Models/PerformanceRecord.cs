using System;

namespace FxInvestmentAdmin.Models
{
    public class PerformanceRecord
    {
        public int Id { get; set; }
        public string FxId { get; set; }
        public int Week { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Results { get; set; }
        public DateTime DateTime { get; set; }
        public string Comments { get; set; }
        public string FilePath { get; set; }
        public int TotalTrades { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal MaxWin { get; set; }
        public decimal MinWin { get; set; }
        public string AccountType { get; set; }
    }
}