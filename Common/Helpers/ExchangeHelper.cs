using System;
using System.Collections.Generic;
using System.Globalization;
using TIKSN.Cmdlets.Common.Models;
using TIKSN.Finance;
using TIKSN.Finance.ForeignExchange.Bank;
using TIKSN.Globalization;
using TIKSN.Time;

namespace TIKSN.Cmdlets.Common.Helpers
{
    public static class ExchangeHelper
    {
        private static Lazy<IEnumerable<BankExchange>> bankCollection = new Lazy<IEnumerable<BankExchange>>(() => CreateBanksCollection(new CurrencyFactory(), new RegionFactory(), new TimeProvider()));

        public static IEnumerable<BankExchange> GetSupportedBanks()
        {
            return bankCollection.Value;
        }

        private static IEnumerable<BankExchange> CreateBanksCollection(
            ICurrencyFactory currencyFactory,
            IRegionFactory regionFactory,
            ITimeProvider timeProvider)
        {
            List<BankExchange> banks = new List<BankExchange>();

            banks.Add(new BankExchange("Bank of Canada", new BankOfCanada(currencyFactory, timeProvider)));
            banks.Add(new BankExchange("Bank of England", new BankOfEngland(currencyFactory, regionFactory, timeProvider)));
            banks.Add(new BankExchange("The Central Bank of the Russian Federation", new BankOfRussia(currencyFactory, timeProvider)));
            banks.Add(new BankExchange("The Central Bank of the Republic of Armenia", new CentralBankOfArmenia(currencyFactory, timeProvider)));
            banks.Add(new BankExchange("European Central Bank", new EuropeanCentralBank(currencyFactory, timeProvider)));
            banks.Add(new BankExchange("Federal Reserve System", new FederalReserveSystem(currencyFactory, timeProvider)));
            banks.Add(new BankExchange("National Bank of Ukraine", new NationalBankOfUkraine(currencyFactory)));
            banks.Add(new BankExchange("Reserve Bank of Australia", new ReserveBankOfAustralia(currencyFactory, timeProvider)));
            banks.Add(new BankExchange("Swiss National Bank", new SwissNationalBank(currencyFactory, timeProvider)));

            return banks;
        }

        private class CurrencyFactory : ICurrencyFactory
        {
            public CurrencyInfo Create(string isoCurrencySymbol)
            {
                return new CurrencyInfo(isoCurrencySymbol);
            }

            public CurrencyInfo Create(RegionInfo region)
            {
                return new CurrencyInfo(region);
            }
        }

        private class RegionFactory : IRegionFactory
        {
            public RegionInfo Create(string name)
            {
                return new RegionInfo(name);
            }
        }
    }
}