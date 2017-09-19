using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets.Commands
{
    [Cmdlet("Add", "CultureAndRegionInfo")]
    public class AddCultureAndRegionInfoCommand : CultureAndRegionInfoCommandBase
    {
        [Parameter(Mandatory = true)]
        public CultureAndRegionModifiers CultureAndRegionModifier { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            CultureAndRegionInfoBuilder builder = new CultureAndRegionInfoBuilder(Name, CultureAndRegionModifier);

            CultureAndRegionInfoDictionary.Add(Name, builder);
        }
    }
}