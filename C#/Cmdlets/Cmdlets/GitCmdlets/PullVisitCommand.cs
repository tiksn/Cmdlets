using LibGit2Sharp;
using System;
using System.Management.Automation;

namespace TIKSN.Cmdlets.GitCmdlets
{
    internal class PullVisitCommand : IVisitCommand
    {
        private readonly Cmdlet cmdlet;
        private readonly bool prune;

        public PullVisitCommand(Cmdlet cmdlet, bool prune)
        {
            this.cmdlet = cmdlet;
            this.prune = prune;
        }

        public VisitResult Execute(Repository repository)
        {
            try
            {
                var fetchOptions = new FetchOptions();
                fetchOptions.Prune = prune;
                fetchOptions.TagFetchMode = TagFetchMode.All;

                var mergeOptions = new MergeOptions();
                mergeOptions.CommitOnSuccess = false;
                mergeOptions.FastForwardStrategy = FastForwardStrategy.FastForwardOnly;

                var pullOptions = new PullOptions();
                pullOptions.FetchOptions = fetchOptions;
                pullOptions.MergeOptions = mergeOptions;

                cmdlet.WriteVerbose($"Pulling repository '{repository.Info.WorkingDirectory}'");
                Commands.Pull(repository, null, pullOptions);
            }
            catch (Exception ex)
            {
                cmdlet.WriteError(new ErrorRecord(ex, "", ErrorCategory.InvalidOperation, repository));
            }

            return null;
        }
    }
}
