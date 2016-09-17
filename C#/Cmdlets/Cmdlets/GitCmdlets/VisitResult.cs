namespace TIKSN.Cmdlets.GitCmdlets
{
    public class VisitResult
    {
        public VisitResult(VisitOutcome outcome, string folder)
        {
            Outcome = outcome;
            Folder = folder;
        }

        public VisitOutcome Outcome { get; private set; }

        public string Folder { get; private set; }
    }
}
