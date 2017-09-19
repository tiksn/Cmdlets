using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets.Commands
{
    [Cmdlet("Set", "CultureAndRegionInfo")]
    public class SetCultureAndRegionInfoCommand : CultureAndRegionInfoCommandBase
    {
        public SetCultureAndRegionInfoCommand()
        {
            //builder.AvailableCalendars
            //builder.CompareInfo
            //builder.ConsoleFallbackUICulture
            //builder.IetfLanguageTag
            //builder.NumberFormat
            //builder.TextInfo
        }

        [Parameter()]
        public string CultureEnglishName { get; set; }

        [Parameter()]
        public string CultureNativeName { get; set; }

        [Parameter()]
        public string CurrencyEnglishName { get; set; }

        [Parameter()]
        public string CurrencyNativeName { get; set; }

        [Parameter()]
        public int? GeoId { get; set; }

        [Parameter()]
        public bool? IsMetric { get; set; }

        [Parameter()]
        public string ISOCurrencySymbol { get; set; }

        [Parameter()]
        public bool? IsRightToLeft { get; set; }

        [Parameter()]
        public int? KeyboardLayoutId { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter()]
        public CultureInfo Parent { get; set; }

        [Parameter()]
        public string RegionEnglishName { get; set; }

        [Parameter()]
        public string RegionNativeName { get; set; }

        [Parameter()]
        public CultureInfo SourceCultureInfo { get; set; }

        [Parameter()]
        public RegionInfo SourceRegionInfo { get; set; }

        [Parameter()]
        public string ThreeLetterISOLanguageName { get; set; }

        [Parameter()]
        public string ThreeLetterISORegionName { get; set; }

        [Parameter()]
        public string ThreeLetterWindowsLanguageName { get; set; }

        [Parameter()]
        public string ThreeLetterWindowsRegionName { get; set; }

        [Parameter()]
        public string TwoLetterISOLanguageName { get; set; }

        [Parameter()]
        public string TwoLetterISORegionName { get; set; }

        protected override void BeginProcessing()
        {
            CultureAndRegionInfoBuilder builder = CultureAndRegionInfoDictionary[Name];

            if (SourceCultureInfo != null)
            {
                builder.LoadDataFromCultureInfo(SourceCultureInfo);
            }

            if (SourceRegionInfo != null)
            {
                builder.LoadDataFromRegionInfo(SourceRegionInfo);
            }

            if (Parent != null)
            {
                builder.Parent = Parent;
            }

            if (CultureEnglishName != null)
            {
                builder.CultureEnglishName = CultureEnglishName;
            }

            if (CultureNativeName != null)
            {
                builder.CultureNativeName = CultureNativeName;
            }

            if (CurrencyNativeName != null)
            {
                builder.CurrencyNativeName = CurrencyNativeName;
            }

            if (CultureEnglishName != null)
            {
                builder.CultureEnglishName = CultureEnglishName;
            }

            if (RegionNativeName != null)
            {
                builder.RegionNativeName = RegionNativeName;
            }

            if (ISOCurrencySymbol != null)
            {
                builder.ISOCurrencySymbol = ISOCurrencySymbol;
            }

            if (GeoId.HasValue)
            {
                builder.GeoId = GeoId.Value;
            }

            if (IsMetric.HasValue)
            {
                builder.IsMetric = IsMetric.Value;
            }

            if (IsRightToLeft.HasValue)
            {
                builder.IsRightToLeft = IsRightToLeft.Value;
            }

            if (KeyboardLayoutId.HasValue)
            {
                builder.KeyboardLayoutId = KeyboardLayoutId.Value;
            }

            if (ThreeLetterISOLanguageName != null)
            {
                builder.ThreeLetterISOLanguageName = ThreeLetterISOLanguageName;
            }

            if (ThreeLetterISORegionName != null)
            {
                builder.ThreeLetterISORegionName = ThreeLetterISORegionName;
            }

            if (ThreeLetterWindowsLanguageName != null)
            {
                builder.ThreeLetterWindowsLanguageName = ThreeLetterWindowsLanguageName;
            }

            if (ThreeLetterWindowsRegionName != null)
            {
                builder.ThreeLetterWindowsRegionName = ThreeLetterWindowsRegionName;
            }

            if (TwoLetterISOLanguageName != null)
            {
                builder.TwoLetterISOLanguageName = TwoLetterISOLanguageName;
            }

            if (TwoLetterISORegionName != null)
            {
                builder.TwoLetterISORegionName = TwoLetterISORegionName;
            }
        }
    }
}