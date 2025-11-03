using System;

namespace FxInvestmentAdmin.Models
{
    public class Trade
    {
        // CSV Mapped Properties
        public string TradeId { get; set; }
        public string ExecId { get; set; }
        public string AccountId { get; set; }
        public string InstrumentSymbol { get; set; }
        public string InstrumentName { get; set; }
        public string OrderId { get; set; }
        public string Currency { get; set; }
        public string ExecutionType { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TakeProfit { get; set; }
        public decimal StopLoss { get; set; }
        public bool GSL { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public decimal Rpl { get; set; }
        public decimal RplConverted { get; set; }

        // Use regular decimals, not nullable
        public decimal Swap { get; set; }
        public decimal SwapConverted { get; set; }

        public decimal Fee { get; set; }
        public DateTime Timestamp { get; set; }
        public string AccountType { get; set; }

        // Calculated Properties
        public decimal NetProfit => RplConverted + SwapConverted - Fee;
        public bool IsWin => NetProfit > 0;
        public bool IsLoss => NetProfit < 0;
        public bool IsBreakeven => NetProfit == 0;
        public string ResultType => IsWin ? "WIN" : IsLoss ? "LOSS" : "BREAKEVEN";

        // Constructor - set default values
        public Trade()
        {
            Currency = "USD";
            Status = "CLOSED";
            AccountType = "CFD";
            GSL = false;
            Fee = 0;
            Swap = 0;
            SwapConverted = 0;
        }

        public bool IsValidTrade()
        {
            if (string.IsNullOrWhiteSpace(TradeId))
                return false;

            if (string.IsNullOrWhiteSpace(InstrumentSymbol))
                return false;

            if (Status != "CLOSED")
                return false;

            if (Timestamp == DateTime.MinValue)
                return false;

            return true;
        }

        public string GetTradeSummary()
        {
            return $"{InstrumentSymbol} | {Quantity} lots | P/L: {NetProfit:C} | {ResultType}";
        }
    }
}