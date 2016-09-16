using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets
{
    public class CultureAndRegionInfoCommandBase : Cmdlet
    {
        protected static Dictionary<string, CultureAndRegionInfoBuilder> CultureAndRegionInfoDictionary = new Dictionary<string, CultureAndRegionInfoBuilder>();
    }
}