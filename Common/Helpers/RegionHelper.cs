using System.Collections.Generic;
using System.Globalization;

namespace TIKSN.Cmdlets.Common.Helpers
{
    public static class RegionHelper
    {
        public static List<RegionInfo> GetAllRegions(bool CultureOnly = false)
        {
            HashSet<string> RegionNames = new HashSet<string>();
            foreach (var CI in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionNames.Add(CI.Name);
            }
            List<RegionInfo> Regions = new List<RegionInfo>();
            foreach (var RegionName in RegionNames)
            {
                Regions.Add(new RegionInfo(RegionName));
            }
            if (!CultureOnly)
            {
                foreach (var Region in Regions)
                {
                    RegionNames.Add(Region.TwoLetterISORegionName);
                }
                Regions.Clear();
                foreach (var RegionName in RegionNames)
                {
                    Regions.Add(new RegionInfo(RegionName));
                }
            }

            return Regions;
        }
    }
}