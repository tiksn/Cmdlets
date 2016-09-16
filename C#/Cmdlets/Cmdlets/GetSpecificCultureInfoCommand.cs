namespace TIKSN.Cmdlets
{
    [System.Management.Automation.Cmdlet("Get", "SpecificCultureInfo")]
    public class GetSpecificCultureInfoCommand : System.Management.Automation.Cmdlet
    {
        [System.Management.Automation.Parameter()]
        public System.Management.Automation.SwitchParameter All { get; set; }

        [System.Management.Automation.Parameter()]
        public string CultureName { get; set; }

        protected override void BeginProcessing()
        {
            if (this.All.IsPresent)
            {
                System.Collections.Generic.List<System.Tuple<System.Globalization.CultureInfo, System.Globalization.CultureInfo>> CulturesAndSpecifics = new System.Collections.Generic.List<System.Tuple<System.Globalization.CultureInfo, System.Globalization.CultureInfo>>();

                foreach (var CC in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
                {
                    CulturesAndSpecifics.Add(new System.Tuple<System.Globalization.CultureInfo, System.Globalization.CultureInfo>(CC, System.Globalization.CultureInfo.CreateSpecificCulture(CC.Name)));
                }

                this.WriteObject(CulturesAndSpecifics, true);
            }
            else if (this.CultureName != null)
            {
                this.WriteObject(System.Globalization.CultureInfo.CreateSpecificCulture(this.CultureName));
            }
        }
    }
}