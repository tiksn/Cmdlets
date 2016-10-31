using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using TIKSN.Cmdlets.GitCmdlets.Models;
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

            var tags = new List<GitTagModel>();

            using (var progress = new PowerShellProgress(this, "Searching ...", "Searching for tags"))
            {
                IProgress<OperationProgressReport> p = progress;

                var count = repository.Tags.Count();

                for (int i = 0; i < count; i++)
                {
                    var tag = repository.Tags.ElementAt(i);

                    tags.Add(new GitTagModel(tag.FriendlyName, tag.Annotation?.Tagger?.ToString(), tag.Annotation?.Message));
                    WriteVerbose($"{tag.FriendlyName} - {tag.Annotation}");

                    p.Report(new OperationProgressReport(i + 1, count));
                }
            }

            WriteObject(tags.OrderByDescending(item => item), true);
        }
    }
}
