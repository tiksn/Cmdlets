using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets.Commands
{
    [Cmdlet("Get", "PseudoCultureInfo")]
    public class GetPseudoCultureInfoCommand : Cmdlet
    {
        protected override void BeginProcessing()
        {
            this.WriteWarning("Multilingual App Toolkit must be installed. For more information visit http://go.microsoft.com/fwlink/?LinkID=262054");

            this.WriteObject(new CultureInfo("qps-ploc"));
        }
    }
}