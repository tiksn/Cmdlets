using System.Management.Automation;

namespace TIKSN.Cmdlets
{
    [Cmdlet("Remove", "CultureAndRegionInfo")]
    public class RemoveCultureAndRegionInfoCommand : CultureAndRegionInfoCommandBase
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            CultureAndRegionInfoDictionary.Remove(Name);
        }
    }
}