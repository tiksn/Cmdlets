using System.Management.Automation;

namespace TIKSN.Cmdlets.GitCmdlets
{
    [Cmdlet("Update", "GitRepository")]
    public class UpdateGitRepositoryCommand : Cmdlet
    {
        [Parameter]
        public SwitchParameter Recurse { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            var scanner = new GitDirectoryScanner(this, Recurse.IsPresent);

            scanner.Scan();
        }
    }
}