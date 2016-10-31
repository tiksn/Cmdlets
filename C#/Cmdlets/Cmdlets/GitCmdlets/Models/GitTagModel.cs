using Semver;
using System;

namespace TIKSN.Cmdlets.GitCmdlets.Models
{
    public class GitTagModel : IComparable<GitTagModel>, IEquatable<GitTagModel>
    {
        public GitTagModel(string name, string tagger, string message)
        {
            Name = name;
            Tagger = tagger;
            Message = message;

            InitializeVersion(0);
        }

        public string Message { get; set; }

        public string Name { get; private set; }

        public string PlatformPrefix { get; private set; }

        public SemVersion PlatformVersion { get; private set; }

        public string Tagger { get; private set; }

        public int CompareTo(GitTagModel other)
        {
            var result = string.Compare(PlatformPrefix, other.PlatformPrefix, StringComparison.Ordinal);

            if (result == 0)
            {
                if (PlatformVersion != null && other.PlatformVersion != null)
                {
                    return PlatformVersion.CompareTo(other.PlatformVersion);
                }
            }

            return result;
        }

        public bool Equals(GitTagModel other)
        {
            return Name == other.Name;
        }

        private void InitializeVersion(int startIndex)
        {
            var i = Name.IndexOf('-', startIndex);

            if (i == -1)
            {
                InitializeVersion(string.Empty, Name);
            }
            else
            {
                if (InitializeVersion(Name.Substring(0, i), Name.Substring(i + 1)))
                    return;

                InitializeVersion(i + 1);
            }
        }

        private bool InitializeVersion(string prefix, string version)
        {
            SemVersion semVersion;
            if (SemVersion.TryParse(version, out semVersion))
            {
                PlatformPrefix = prefix;
                PlatformVersion = semVersion;

                return true;
            }

            return false;
        }
    }
}