using System.Data;
using System.Linq;

namespace TIKSN.Cmdlets
{
    public class ThreeLetterWindowsLanguageName
    {
        public System.Collections.Generic.List<System.Globalization.CultureInfo> Cultures = new System.Collections.Generic.List<System.Globalization.CultureInfo>();
        public string Name;

        public int Count
        {
            get { return this.Cultures.Count; }
        }

        public int NeutralsCount
        {
            get { return this.Cultures.Where(C => C.IsNeutralCulture).Count(); }
        }

        public int RegionalsCount
        {
            get
            {
                var Specifics = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures);

                return this.Cultures.Where(C => Specifics.Contains(C)).Count();
            }
        }
    }
}