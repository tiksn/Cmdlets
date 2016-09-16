using System.Management.Automation;

namespace TIKSN.Cmdlets
{
    [Cmdlet("Get", "CultureAndRegionInfo")]
    public class GetCultureAndRegionInfoCommand : CultureAndRegionInfoCommandBase
    {
        [Parameter()]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(CultureAndRegionInfoDictionary, true);
            }
            else
            {
                WriteObject(CultureAndRegionInfoDictionary[Name]);
            }
        }
    }
}