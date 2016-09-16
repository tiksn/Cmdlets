using System.Globalization;
using System.Management.Automation;

namespace TIKSN.Cmdlets
{
    [Cmdlet("Import", "CultureAndRegionInfo")]
    public class ImportCultureAndRegionInfoCommand : CultureAndRegionInfoCommandBase
    {
        [Parameter(Mandatory = true)]
        public string FilePath { get; set; }

        protected override void BeginProcessing()
        {
            CultureAndRegionInfoBuilder builder = CultureAndRegionInfoBuilder.CreateFromLdml(FilePath);

            CultureAndRegionInfoDictionary.Add(builder.CultureName, builder);
        }
    }
}