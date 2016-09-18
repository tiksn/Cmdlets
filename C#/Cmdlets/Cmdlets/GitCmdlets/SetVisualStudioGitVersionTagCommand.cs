using LibGit2Sharp;
using System;
using System.Linq;
using System.Management.Automation;
using TIKSN.Progress;

namespace TIKSN.Cmdlets.GitCmdlets
{
    [Cmdlet("Set", "VisualStudioGitVersionTag")]
    public class SetVisualStudioGitVersionTagCommand : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            var repository = new Repository(SessionState.Path.CurrentFileSystemLocation.Path);

            var commits = repository.Commits.Where(c => c.Tree.Any(t => t.TargetType == TreeEntryTargetType.Blob && t.Name.Equals("Package.appxmanifest", StringComparison.OrdinalIgnoreCase)));

            using (var progress = new PowerShellProgress(this, "Searching ...", "Searching for package commits"))
            {
                IProgress<OperationProgressReport> p = progress;

                var count = repository.Commits.Count();

                for (int i = 0; i < count; i++)
                {
                    var commit = repository.Commits.ElementAt(i);
                    var result = ExtractPackageTreeEntry(commit.Tree);

                    if (result)
                        WriteVerbose($"{commit.Sha} {commit.MessageShort}");

                    p.Report(new OperationProgressReport(i + 1, count));
                }
            }

            WriteObject(commits, true);
        }

        private static bool ExtractPackageTreeEntry(Tree tree)
        {
            foreach (var treeItem in tree)
            {
                if (treeItem.TargetType == TreeEntryTargetType.Blob && string.Equals(treeItem.Name, "Package.appxmanifest", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (treeItem.TargetType == TreeEntryTargetType.Tree)
                {
                    var subtree = (Tree)treeItem.Target;

                    return ExtractPackageTreeEntry(subtree);
                }
            }

            return false;
        }
    }
}
