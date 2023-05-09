using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TextSpeechKT.Server
{
    public interface IConvertVoice
    {
        List<InstalledVoice> GetLanguageList();
        void ToVoice(string? Iuuma, string? FileType, bool TalkType, string mojiStr,string[] MsgArr);
    }
}
