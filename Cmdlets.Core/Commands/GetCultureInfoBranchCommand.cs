namespace TIKSN.Cmdlets.Core.Commands
{
    [System.Management.Automation.Cmdlet("Get", "CultureInfoBranch")]
    public class GetCultureInfoBranchCommand : System.Management.Automation.Cmdlet
    {
        [System.Management.Automation.Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            System.Collections.Generic.List<System.Globalization.CultureInfo> cultureBranch = new System.Collections.Generic.List<System.Globalization.CultureInfo>();

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(this.Name);

            cultureBranch.Add(culture);

            AddParent(culture, cultureBranch);

            this.WriteObject(cultureBranch, true);
        }

        private void AddParent(System.Globalization.CultureInfo culture, System.Collections.Generic.List<System.Globalization.CultureInfo> cultureBranch)
        {
            cultureBranch.Add(culture.Parent);

            if (culture.Parent != null && !culture.Parent.Equals(System.Globalization.CultureInfo.InvariantCulture))
            {
                AddParent(culture.Parent, cultureBranch);
            }
        }
    }
}