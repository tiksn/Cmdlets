using LibGit2Sharp;
using System;
using System.Linq;
using System.Management.Automation;
using TIKSN.Progress;

namespace TIKSN.Cmdlets.GitCmdlets
{
    [Cmdlet("Get", "GitVersionTagTable")]
    public class GetGitVersionTagTableCommand : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            var repository = new Repository(SessionState.Path.CurrentFileSystemLocation.Path);

            using (var progress = new PowerShellProgress(this, "Searching ...", "Searching for tags"))
            {
                IProgress<OperationProgressReport> p = progress;

                var count = repository.Tags.Count();

                for (int i = 0; i < count; i++)
                {
                    var tag = repository.Tags.ElementAt(i);

                    WriteVerbose($"{tag.CanonicalName}");

                    p.Report(new OperationProgressReport(i + 1, count));
                }
            }
        }
    }
}
