using System.Speech.Synthesis;


namespace TextSpeechKT.Server
{
    public interface IConvertVoice
    {
        List<InstalledVoice> GetLanguageList();
        void ToVoice(string? Iuuma, string? FileType, bool TalkType, string mojiStr,string[] MsgArr);
    }
}
