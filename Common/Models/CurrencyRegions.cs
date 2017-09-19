namespace TIKSN.Cmdlets.Common.Models
{
    public class CurrencyRegions
    {
        private System.Collections.Generic.List<System.Globalization.RegionInfo> _Regions;

        public CurrencyRegions()
        {
            this._Regions = new System.Collections.Generic.List<System.Globalization.RegionInfo>();
        }

        public int Count
        {
            get { return this.Regions.Count; }
        }

        public TIKSN.Finance.CurrencyInfo Currency { get; set; }

        public System.Collections.Generic.List<System.Globalization.RegionInfo> Regions
        {
            get { return this._Regions; }
        }
    }
}