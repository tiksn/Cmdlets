using System.Management.Automation;
using System.Speech.Synthesis;

namespace TIKSN.Cmdlets
{
    [Cmdlet("Get", "InstalledVoice")]
    public class GetInstalledVoiceCommand : Cmdlet
    {
        private readonly SpeechSynthesizer speaker;

        public GetInstalledVoiceCommand()
        {
            speaker = new SpeechSynthesizer();
        }

        protected override void BeginProcessing()
        {
            WriteObject(speaker.GetInstalledVoices(), true);
        }
    }
}
