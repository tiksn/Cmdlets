using LibGit2Sharp;
using System;
using System.Linq;
using System.Management.Automation;

namespace TIKSN.Cmdlets.GitCmdlets
{
    internal class FetchVisitCommand : IVisitCommand
    {
        private readonly Cmdlet cmdlet;
        private readonly bool prune;

        public FetchVisitCommand(Cmdlet cmdlet, bool prune)
        {
            this.cmdlet = cmdlet;
            this.prune = prune;
        }

        public VisitResult Execute(Repository repository)
        {
            var visitOutcome = VisitOutcome.None;

            foreach (var remote in repository.Network.Remotes)
            {
                try
                {
                    var fetchOptions = new FetchOptions();
                    fetchOptions.Prune = prune;
                    fetchOptions.TagFetchMode = TagFetchMode.All;

                    cmdlet.WriteVerbose($"Fetching remote '{remote.Name}' of repository '{repository.Info.Path}'");
                    Commands.Fetch(repository, remote.Name, remote.RefSpecs.Select(rs=>rs.Specification), fetchOptions, "Log Message");

                    if (visitOutcome == VisitOutcome.None)
                        visitOutcome = VisitOutcome.Fetched;
                }
                catch (Exception ex)
                {
                    cmdlet.WriteError(new ErrorRecord(ex, "", ErrorCategory.InvalidOperation, repository));
                    visitOutcome = VisitOutcome.Failed;
                }
            }

            return new VisitResult(visitOutcome, repository.Info.WorkingDirectory);
        }
    }
}
