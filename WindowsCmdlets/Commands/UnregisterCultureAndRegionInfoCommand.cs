using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets.Commands
{
    [Cmdlet("Unregister", "CultureAndRegionInfo")]
    public class UnregisterCultureAndRegionInfoCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            CultureAndRegionInfoBuilder.Unregister(Name);
        }
    }
}