using System;
using System.Collections.Generic;
using TIKSN.Cmdlets.Common.Models;
using TIKSN.Finance.ForeignExchange;

namespace TIKSN.Cmdlets.Common.Helpers
{
    public static class ExchangeHelper
    {
        private static Lazy<IEnumerable<BankExchange>> bankCollection = new Lazy<IEnumerable<BankExchange>>(CreateBanksCollection);

        public static IEnumerable<BankExchange> GetSupportedBanks()
        {
            return bankCollection.Value;
        }

        private static IEnumerable<BankExchange> CreateBanksCollection()
        {
            List<BankExchange> banks = new List<BankExchange>();

            banks.Add(new BankExchange("Bank of Canada", new BankOfCanada()));
            banks.Add(new BankExchange("Bank of England", new BankOfEngland()));
            banks.Add(new BankExchange("The Central Bank of the Russian Federation", new BankOfRussia()));
            banks.Add(new BankExchange("The Central Bank of the Republic of Armenia", new CentralBankOfArmenia()));
            banks.Add(new BankExchange("European Central Bank", new EuropeanCentralBank()));
            banks.Add(new BankExchange("Federal Reserve System", new FederalReserveSystem()));
            banks.Add(new BankExchange("National Bank of Ukraine", new NationalBankOfUkraine()));
            banks.Add(new BankExchange("Reserve Bank of Australia", new ReserveBankOfAustralia()));
            banks.Add(new BankExchange("Swiss National Bank", new SwissNationalBank()));

            return banks;
        }
    }
}