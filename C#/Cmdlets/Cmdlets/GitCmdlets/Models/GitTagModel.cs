namespace TIKSN.Cmdlets.GitCmdlets.Models
{
    public class GitTagModel
    {
        public GitTagModel(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
