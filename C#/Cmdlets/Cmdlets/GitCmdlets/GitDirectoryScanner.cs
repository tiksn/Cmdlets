using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace TIKSN.Cmdlets.GitCmdlets
{
    internal class GitDirectoryScanner
    {
        private readonly PSCmdlet cmdlet;
        private readonly bool recurse;
        private readonly IVisitCommand visitCommand;
        public GitDirectoryScanner(PSCmdlet cmdlet, IVisitCommand visitCommand, bool recurse)
        {
            this.cmdlet = cmdlet;
            this.visitCommand = visitCommand;
            this.recurse = recurse;
        }

        public void Scan()
        {
            var result = new List<VisitResult>();

            var visitResult = VisitDirectory(cmdlet.SessionState.Path.CurrentFileSystemLocation.Path);
            if (visitResult != null)
                result.Add(visitResult);

            var scanResult = ScanDirectories(cmdlet.SessionState.Path.CurrentFileSystemLocation.Path);
            result.AddRange(scanResult);

            if(result.Count == 0)
            {
                cmdlet.WriteWarning("No Git repository is found.");
            }

            cmdlet.WriteObject(result, true);
        }

        private IEnumerable<VisitResult> ScanDirectories(string folder)
        {
            var result = new List<VisitResult>();

            foreach (var subfolder in Directory.GetDirectories(folder))
            {
                var subfolderVisitResult = VisitDirectory(subfolder);

                if(subfolderVisitResult == null)
                {
                    if(recurse)
                    {
                        var subfolderResult = ScanDirectories(subfolder);

                        result.AddRange(subfolderResult);
                    }
                }
                else
                {
                    result.Add(subfolderVisitResult);
                }
            }

            return result;
        }

        private VisitResult VisitDirectory(string folder)
        {
            if(Repository.IsValid(folder))
            {
                cmdlet.WriteVerbose($"Git repository is found under folder: {folder}");

                var repository = new Repository(folder);

                try
                {
                    return visitCommand.Execute(repository);
                }
                catch (Exception ex)
                {
                    cmdlet.WriteError(new ErrorRecord(ex, "", ErrorCategory.InvalidOperation, repository));
                }
            }

            return null;
        }
    }
}