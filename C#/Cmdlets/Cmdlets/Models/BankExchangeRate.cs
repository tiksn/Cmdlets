using TIKSN.Finance;

namespace TIKSN.Cmdlets.Models
{
    public class BankExchangeRate
    {
        public BankExchangeRate(string BankName, CurrencyPair CurrencyPair, decimal Rate)
        {
            this.BankName = BankName;
            this.CurrencyPair = CurrencyPair;
            this.Rate = Rate;
        }

        public string BankName { get; }

        public CurrencyPair CurrencyPair { get; }

        public decimal Rate { get; }
    }
}