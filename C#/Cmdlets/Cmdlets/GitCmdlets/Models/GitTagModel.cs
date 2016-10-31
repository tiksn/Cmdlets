namespace TIKSN.Cmdlets.GitCmdlets.Models
{
    public class GitTagModel
    {
        public GitTagModel(string name, string tagger, string message)
        {
            Name = name;
            Tagger = tagger;
            Message = message;
        }

        public string Name { get; private set; }

        public string Tagger { get; private set; }

        public string Message { get; set; }
    }
}
