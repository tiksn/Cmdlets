using TIKSN.Finance;

namespace TIKSN.Cmdlets.Common.Models
{
    public class BankExchange
    {
        public BankExchange(string BankName, ICurrencyConverter Exchange)
        {
            this.BankName = BankName;
            this.Exchange = Exchange;
        }

        public string BankName { get; }

        public ICurrencyConverter Exchange { get; }
    }
}