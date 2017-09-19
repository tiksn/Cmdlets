using System.Linq;
using TIKSN.Cmdlets.Common.Models;

namespace TIKSN.Cmdlets.Core.Commands
{
    [System.Management.Automation.Cmdlet("Get", "ThreeLetterWindowsLanguageName")]
    public class GetThreeLetterWindowsLanguageNameCommand : System.Management.Automation.Cmdlet
    {
        protected override void BeginProcessing()
        {
            System.Collections.Generic.List<System.Tuple<string, System.Globalization.CultureInfo>> Cultures = new System.Collections.Generic.List<System.Tuple<string, System.Globalization.CultureInfo>>();

            foreach (var CC in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                Cultures.Add(new System.Tuple<string, System.Globalization.CultureInfo>(CC.ThreeLetterWindowsLanguageName, CC));
            }

            var TLW = Cultures.ToLookup(T => T.Item1, T => T.Item2);

            System.Collections.Generic.List<ThreeLetterWindowsLanguageName> TLWLN = new System.Collections.Generic.List<ThreeLetterWindowsLanguageName>();

            foreach (var Lang in TLW)
            {
                ThreeLetterWindowsLanguageName TL = new ThreeLetterWindowsLanguageName();

                TL.Name = Lang.Key;

                foreach (var TC in Lang)
                {
                    TL.Cultures.Add(TC);
                }

                TLWLN.Add(TL);
            }

            this.WriteObject(TLWLN, true);
        }
    }
}