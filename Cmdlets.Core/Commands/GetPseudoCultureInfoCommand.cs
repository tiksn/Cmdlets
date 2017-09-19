namespace TIKSN.Cmdlets.Core.Commands
{
    [System.Management.Automation.Cmdlet("Get", "PseudoCultureInfo")]
    public class GetPseudoCultureInfoCommand : System.Management.Automation.Cmdlet
    {
        protected override void BeginProcessing()
        {
            this.WriteWarning("Multilingual App Toolkit must be installed. For more information visit http://go.microsoft.com/fwlink/?LinkID=262054");

            this.WriteObject(new System.Globalization.CultureInfo("qps-ploc"));
        }
    }
}