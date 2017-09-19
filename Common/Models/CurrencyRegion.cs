namespace TIKSN.Cmdlets.Common.Models
{
    public class CurrencyRegion
    {
        private TIKSN.Finance.CurrencyInfo _Currency;

        private System.Globalization.RegionInfo _Region;

        public CurrencyRegion(System.Globalization.RegionInfo Region)
        {
            this._Region = Region;
            this._Currency = new TIKSN.Finance.CurrencyInfo(Region);
        }

        public TIKSN.Finance.CurrencyInfo Currency
        {
            get { return this._Currency; }
        }

        public System.Globalization.RegionInfo Region
        {
            get { return this._Region; }
        }
    }
}