using CsvHelper.Configuration;
using FxInvestmentAdmin.Models;

namespace FxInvestmentAdmin.Services
{
    public sealed class TradeMap : ClassMap<Trade>
    {
        public TradeMap()
        {
            Map(m => m.TradeId).Name("Trade Id");
            Map(m => m.ExecId).Name("Exec Id");
            Map(m => m.AccountId).Name("Account Id");
            Map(m => m.InstrumentSymbol).Name("Instrument Symbol");
            Map(m => m.InstrumentName).Name("Instrument Name");
            Map(m => m.OrderId).Name("Order Id");
            Map(m => m.Currency).Name("Currency");
            Map(m => m.ExecutionType).Name("Execution Type");
            Map(m => m.Quantity).Name("Quantity");
            Map(m => m.Price).Name("Price");
            Map(m => m.TakeProfit).Name("Take Profit").Optional();
            Map(m => m.StopLoss).Name("Stop Loss").Optional();
            Map(m => m.GSL).Name("gsl").TypeConverterOption.BooleanValues(true, false, "true", "false");
            Map(m => m.Source).Name("Source");
            Map(m => m.Status).Name("Status");
            Map(m => m.Rpl).Name("rpl");
            Map(m => m.RplConverted).Name("Rpl Converted");

            // Skip swap fields entirely - they'll use default values from constructor
            // Map(m => m.Swap).Name("Swap");
            // Map(m => m.SwapConverted).Name("Swap Converted");

            Map(m => m.Fee).Name("Fee");
            Map(m => m.Timestamp).Name("Timestamp").TypeConverterOption.Format("yyyy-MM-dd HH:mm:ss");
            Map(m => m.AccountType).Name("Account type");
        }
    }
}