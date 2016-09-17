using LibGit2Sharp;

namespace TIKSN.Cmdlets.GitCmdlets
{
    internal interface IVisitCommand
    {
        VisitResult Execute(Repository repository);
    }
}
