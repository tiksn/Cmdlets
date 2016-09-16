using GitTools.Git;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace TIKSN.Cmdlets.GitCmdlets
{
    public class GitDirectoryScanner
    {
        private readonly Cmdlet cmdlet;
        private readonly bool recurse;

        public GitDirectoryScanner(Cmdlet cmdlet, bool recurse)
        {
            this.cmdlet = cmdlet;
            this.recurse = recurse;
        }

        public void Scan()
        {
            cmdlet.WriteObject(GitDirFinder.TreeWalkForDotGitDir("."));
            return;
            var result = new List<int>();

            VisitDirectory(".");
            ScanDirectories(".");

            if(result.Count == 0)
            {
                cmdlet.WriteWarning("No Git repository is found.");
            }


            cmdlet.WriteObject(result, true);
        }

        private void ScanDirectories(string folder)
        {
            throw new NotImplementedException();
        }

        private void VisitDirectory(string folder)
        {
            throw new NotImplementedException();
        }
    }
}