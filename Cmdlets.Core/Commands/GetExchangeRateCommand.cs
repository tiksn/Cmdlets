using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using TIKSN.Cmdlets.Common.Helpers;
using TIKSN.Cmdlets.Common.Models;
using TIKSN.Finance;

namespace TIKSN.Cmdlets.Core.Commands
{

    [Cmdlet("Get", "ExchangeRate")]
    public class GetExchangeRateCommand : Command
    {
        [Parameter(Mandatory = true)]
        public string BaseCurrency { get; set; }

        [Parameter(Mandatory = true)]
        public string CounterCurrency { get; set; }

        [Parameter(Mandatory = false)]
        public DateTimeOffset? AsOn { get; set; }

        protected override async Task ProcessRecordAsync()
        {
            var banks = ExchangeHelper.GetSupportedBanks();
            var exchangeDate = AsOn.HasValue ? AsOn.Value : DateTimeOffset.Now;

            List<BankExchangeRate> result = new List<BankExchangeRate>();

            CurrencyPair pair = new CurrencyPair(new CurrencyInfo(BaseCurrency), new CurrencyInfo(CounterCurrency));
            ProgressRecord BankProgressRecord = new ProgressRecord(0, "Retrieving exchange rates from bank", "Bank name");


            foreach (var bank in banks)
            {
                BankProgressRecord.StatusDescription = bank.BankName;
                WriteProgress(BankProgressRecord);

                WriteVerbose(string.Format("Retrieving supported currencies from {0}", bank.BankName));

                try
                {
                    var pairs = await bank.Exchange.GetCurrencyPairsAsync(exchangeDate);

                    if (pairs.Any(item => item.Equals(pair)))
                    {
                        WriteVerbose(string.Format("Retrieving {1} exchange rate from {0}", bank.BankName, pair));
                        var rate = await bank.Exchange.GetExchangeRateAsync(pair, exchangeDate);
                        result.Add(new BankExchangeRate(bank.BankName, pair, rate));
                    }
                }
                catch (Exception ex)
                {
                    WriteError(new ErrorRecord(ex, "", ErrorCategory.InvalidResult, null));
                }
            }

            WriteObject(result, true);

            if (result.Count == 0)
            {
                WriteWarning(string.Format("Exchange rate for {0} is not found.", pair));
            }

            BankProgressRecord.RecordType = ProgressRecordType.Completed;
            WriteProgress(BankProgressRecord);
        }
    }
}