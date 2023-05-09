using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextSpeechKT.Server
{
    public class ConvertVoice: IConvertVoice
    {

        public List<InstalledVoice> GetLanguageList()
        {
            return new SpeechSynthesizer().GetInstalledVoices().ToList();
        }

        public async void ToVoice(string? Iuuma,string? FileType,bool TalkType, string mojiStr, string[] MsgArr)
        {
            if (mojiStr == "") mojiStr = MsgArr[0];
            Form2 fr2 = new();
            fr2.Show();
            fr2.UpdateprogressBar(10, MsgArr[1]);
            await Task.Run(() =>
            {
                using (SpeechSynthesizer RunVoice = new SpeechSynthesizer())
                {
                    if (FileType != "─") RunVoice.SetOutputToWaveFile($"outFile\\vouceFile{DateTime.Now.ToString("HHmmss")}{FileType}");


                    if (TalkType)
                    {
                        //自然模式
                        var pb = new PromptBuilder();
                        pb.StartVoice(Iuuma?.TrimStart());
                        pb.AppendSsmlMarkup(mojiStr);
                        pb.EndVoice();
                        RunVoice.Speak(pb);
                    }
                    else
                    {
                        //標準模式
                        RunVoice.SelectVoice(Iuuma?.TrimStart());
                        //分段讀取
                        string[] mojiStrArr = mojiStr.Split(new char[] { '\n', '。', '.' });
                        for (int r = 0; r < mojiStrArr.Length; r++)
                        {
                            RunVoice.Speak(mojiStrArr[r]);
                            fr2.UpdateprogressBar((int)((double)(r + 1) / mojiStrArr.Length * 100), MsgArr[2]);
                        }
                    }

                    if (FileType != "─")
                    {
                        RunVoice.SetOutputToNull();
                        MessageBox.Show(MsgArr[4]);
                    }
                }
            });
            fr2.UpdateprogressBar(100, MsgArr[3]);
        }
    }
}
