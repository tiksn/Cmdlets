using TIKSN.Cmdlets.Common.Helpers;

namespace TIKSN.Cmdlets.Core.Commands
{
    [System.Management.Automation.Cmdlet("Get", "RegionInfo")]
    public class GetRegionInfoCommand : System.Management.Automation.Cmdlet
    {
        [System.Management.Automation.Parameter()]
        public System.Management.Automation.SwitchParameter All { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false)]
        public System.Management.Automation.SwitchParameter CultureOnly { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                var Region = new System.Globalization.RegionInfo(this.Name);

                this.WriteObject(Region);
            }
            else if (this.All.IsPresent || this.CultureOnly.IsPresent)
            {
                var Regions = RegionHelper.GetAllRegions(this.CultureOnly.IsPresent);

                this.WriteObject(Regions, true);
            }
            else
            {
                this.WriteObject(System.Globalization.RegionInfo.CurrentRegion);
            }
        }
    }
}