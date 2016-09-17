using System.Management.Automation;

namespace TIKSN.Cmdlets.GitCmdlets
{
    [Cmdlet("Update", "GitRepository")]
    public class UpdateGitRepositoryCommand : PSCmdlet
    {
        [Parameter]
        public SwitchParameter Recurse { get; set; }

        [Parameter]
        public SwitchParameter Prune { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            var visitCommand = new FetchVisitCommand(this, Prune.IsPresent);
            var scanner = new GitDirectoryScanner(this, visitCommand, Recurse.IsPresent);

            scanner.Scan();
        }
    }
}