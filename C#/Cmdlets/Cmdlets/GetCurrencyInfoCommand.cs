using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using TIKSN.Cmdlets.Helpers;

namespace TIKSN.Cmdlets
{
    [Cmdlet("Get", "CurrencyInfo")]
    public class GetCurrencyInfoCommand : Cmdlet
    {
        [Parameter()]
        public SwitchParameter CurrencyRegions { get; set; }

        [Parameter()]
        public string ISOCurrencySymbol { get; set; }

        protected override void BeginProcessing()
        {
            bool ISOCodeSpecified = !string.IsNullOrEmpty(this.ISOCurrencySymbol);

            if (this.CurrencyRegions.IsPresent)
            {
                if (ISOCodeSpecified)
                {
                    var RegionalCurrencies = this.GetSpecificCurrencyRegions(this.ISOCurrencySymbol);

                    this.WriteObject(RegionalCurrencies, true);
                }
                else
                {
                    var RegionalCurrencies = this.GetAllCurrencyRegions();

                    this.WriteObject(RegionalCurrencies, true);
                }
            }
            else
            {
                if (ISOCodeSpecified)
                {
                    var Currencies = this.GetSpecificCurrency(this.ISOCurrencySymbol);

                    this.WriteObject(Currencies, true);
                }
                else
                {
                    var Currencies = this.GetAllCurrencies();

                    this.WriteObject(Currencies, true);
                }
            }
        }

        private HashSet<Finance.CurrencyInfo> GetAllCurrencies()
        {
            var Regions = RegionHelper.GetAllRegions();

            HashSet<Finance.CurrencyInfo> Currencies = new HashSet<Finance.CurrencyInfo>();

            foreach (var Region in Regions)
            {
                Currencies.Add(new TIKSN.Finance.CurrencyInfo(Region));
            }

            return Currencies;
        }

        private List<CurrencyRegions> GetAllCurrencyRegions()
        {
            var Regions = RegionHelper.GetAllRegions();

            var RegionalCurrencies = new List<CurrencyRegions>();

            foreach (var Region in Regions)
            {
                var Currency = new TIKSN.Finance.CurrencyInfo(Region);

                if (RegionalCurrencies.Any(RC => RC.Currency == Currency))
                {
                    var RegionalCurrency = RegionalCurrencies.Single(RC => RC.Currency == Currency);

                    RegionalCurrency.Regions.Add(Region);
                }
                else
                {
                    var RegionalCurrency = new CurrencyRegions();

                    RegionalCurrency.Currency = Currency;
                    RegionalCurrency.Regions.Add(Region);

                    RegionalCurrencies.Add(RegionalCurrency);
                }
            }

            return RegionalCurrencies;
        }

        private System.Collections.Generic.IEnumerable<TIKSN.Finance.CurrencyInfo> GetSpecificCurrency(string ISOCode)
        {
            var Regions = RegionHelper.GetAllRegions();

            List<Finance.CurrencyInfo> Currencies = new List<Finance.CurrencyInfo>();

            foreach (var Region in Regions)
            {
                if (string.Compare(Region.ISOCurrencySymbol, ISOCode, System.StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    Currencies.Add(new TIKSN.Finance.CurrencyInfo(Region));
                }
            }

            return Currencies;
        }

        private System.Collections.Generic.List<CurrencyRegion> GetSpecificCurrencyRegions(string ISOCode)
        {
            var Regions = RegionHelper.GetAllRegions();

            var Result = new System.Collections.Generic.List<CurrencyRegion>();

            foreach (var Region in Regions)
            {
                if (string.Compare(Region.ISOCurrencySymbol, ISOCode, System.StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    Result.Add(new CurrencyRegion(Region));
                }
            }

            return Result;
        }
    }
}