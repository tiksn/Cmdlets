using System.Management.Automation;

namespace TIKSN.Cmdlets.Commands
{
    [Cmdlet("Export", "CultureAndRegionInfo")]
    public class ExportCultureAndRegionInfoCommand : CultureAndRegionInfoCommandBase
    {
        [Parameter(Mandatory = true)]
        public string FilePath { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            CultureAndRegionInfoDictionary[Name].Save(FilePath);
        }
    }
}