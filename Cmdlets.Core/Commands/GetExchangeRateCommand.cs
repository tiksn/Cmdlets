using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using TIKSN.Cmdlets.Commands;
using TIKSN.Cmdlets.Common.Helpers;
using TIKSN.Cmdlets.Common.Models;
using TIKSN.Finance;
using TIKSN.Time;

namespace TIKSN.Cmdlets.Core.Commands
{
    [Cmdlet("Get", "ExchangeRate")]
    public class GetExchangeRateCommand : Command
    {
        [Parameter(Mandatory = false)]
        public DateTimeOffset? AsOn { get; set; }

        [Parameter(Mandatory = true)]
        public string BaseCurrency { get; set; }

        [Parameter(Mandatory = true)]
        public string CounterCurrency { get; set; }

        protected override async Task ProcessRecordAsync(CancellationToken cancellationToken)
        {
            var banks = ExchangeHelper.GetSupportedBanks();
            var timeProvider = ServiceProvider.GetRequiredService<ITimeProvider>();
            var exchangeDate = AsOn.HasValue ? AsOn.Value : timeProvider.GetCurrentTime();

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
                    var pairs = await bank.Exchange.GetCurrencyPairsAsync(exchangeDate, cancellationToken);

                    if (pairs.Any(item => item.Equals(pair)))
                    {
                        WriteVerbose(string.Format("Retrieving {1} exchange rate from {0}", bank.BankName, pair));
                        var rate = await bank.Exchange.GetExchangeRateAsync(pair, exchangeDate, cancellationToken);
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