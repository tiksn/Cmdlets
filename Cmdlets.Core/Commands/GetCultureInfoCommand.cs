using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets.Core.Commands
{
    [Cmdlet("Get", "CultureInfo")]
    public class GetCultureInfoCommand : Cmdlet
    {
        public GetCultureInfoCommand()
        {
            CultureTypes = CultureTypes.AllCultures;
        }

        [Parameter()]
        public SwitchParameter All { get; set; }

        [Parameter()]
        public CultureTypes CultureTypes { get; set; }

        [Parameter()]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (this.All.IsPresent)
            {
                this.WriteObject(CultureInfo.GetCultures(this.CultureTypes), true);
            }
            else if (this.Name != null)
            {
                this.WriteObject(new CultureInfo(this.Name));
            }
            else
            {
                System.Collections.Generic.Dictionary<string, CultureInfo> CurrentCultures = new System.Collections.Generic.Dictionary<string, CultureInfo>();

                CurrentCultures.Add("CurrentCulture", CultureInfo.CurrentCulture);
                CurrentCultures.Add("CurrentUICulture", CultureInfo.CurrentUICulture);

                this.WriteObject(CurrentCultures, true);
            }
        }
    }
}