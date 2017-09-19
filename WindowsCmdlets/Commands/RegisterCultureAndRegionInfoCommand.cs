using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets.Commands
{
    [Cmdlet("Register", "CultureAndRegionInfo")]
    public class RegisterCultureAndRegionInfoCommand : CultureAndRegionInfoCommandBase
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            CultureAndRegionInfoBuilder builder = CultureAndRegionInfoDictionary[Name];

            builder.Register();
        }
    }
}