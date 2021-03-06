using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets.Commands
{
    [Cmdlet("Get", "PseudoRegionInfo")]
    public class GetPseudoRegionInfoCommand : Cmdlet
    {
        protected override void BeginProcessing()
        {
            this.WriteWarning("Multilingual App Toolkit must be installed. For more information visit http://go.microsoft.com/fwlink/?LinkID=262054");

            this.WriteObject(new RegionInfo("qps-ploc"));
        }
    }
}