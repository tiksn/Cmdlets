namespace TIKSN.Cmdlets
{
    [System.Management.Automation.Cmdlet("Get", "ChildCultureInfo")]
    public class GetChildCultureInfoCommand : System.Management.Automation.Cmdlet
    {
        [System.Management.Automation.Parameter(Mandatory = false)]
        public string ParentCultureName { get; set; }

        [System.Management.Automation.Parameter()]
        public System.Management.Automation.SwitchParameter Tree { get; set; }

        protected override void BeginProcessing()
        {
            var ParentName = this.ParentCultureName;

            if (this.ParentCultureName == null)
            {
                this.WriteVerbose("Parent Name is not specified.");
                ParentName = string.Empty;
            }

            var ParentCultureInfo = new System.Globalization.CultureInfo(ParentName);
            var ChildCultures = GetChildCultures(ParentCultureInfo, this.Tree.IsPresent);

            foreach (System.Globalization.CultureInfo C in ChildCultures)
            {
                this.WriteObject(C);
            }
        }

        private static System.Collections.Generic.IEnumerable<System.Globalization.CultureInfo> GetChildCultures(System.Globalization.CultureInfo ParentCulture, bool Tree)
        {
            var Result = new System.Collections.Generic.List<System.Globalization.CultureInfo>();

            foreach (System.Globalization.CultureInfo C in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                if (C.Parent.Equals(ParentCulture) && !C.Equals(System.Globalization.CultureInfo.InvariantCulture))
                {
                    Result.Add(C);

                    if (Tree)
                    {
                        Result.AddRange(GetChildCultures(C, Tree));
                    }
                }
            }

            return Result;
        }
    }
}