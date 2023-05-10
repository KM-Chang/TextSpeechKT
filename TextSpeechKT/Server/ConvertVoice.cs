using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;

namespace TextSpeechKT.Server
{
    public class ConvertVoice: IConvertVoice
    {

        public List<InstalledVoice> GetLanguageList()
        {
            return new SpeechSynthesizer().GetInstalledVoices().ToList();
        }

        /// <summary>
        /// 合成聲音
        /// </summary>
        /// <param name="Iuuma">使用語音腳色</param>
        /// <param name="FileType">匯出檔案</param>
        /// <param name="TalkType">生成模式</param>
        /// <param name="mojiStr">內容</param>
        /// <param name="MsgArr">雙語進度內容</param>
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
                        //調整模式
                        mojiStr = mojiStr.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                        mojiStr = mojiStr.Replace("①", "1").Replace("②", "2").Replace("③", "3").Replace("④", "4");

                        //追加句子內停頓語氣
                        mojiStr = Regex.Replace(mojiStr,@"[\、\;\；\.]", "<break time=\"220ms\" />");
                        mojiStr = Regex.Replace(mojiStr, @"[\,\，\：]", "<break strength=\"weak\" />");
                        fr2.UpdateprogressBar(35, MsgArr[2]);

                        //追加句子的強調處
                        mojiStr= toSSLMrule(@"\[[^\]]+\]|\{[^\}]+\}|\「[^\」]+\」|\『[^\』]+\』|\《[^\》]+\》|\【[^\】]+\】|\“【[^\”]+\”", mojiStr, "<emphasis level=\"moderate\">", "</say-as>");
                        //變更拼音讀法
                        mojiStr = toSSLMrule(@"^[a-z]+(-[a-z]+)*$", mojiStr, "<say-as interpret-as=\"characters\">", "</say-as>");
                        //變更日期讀法
                        mojiStr = toSSLMrule(@"^(?:(?:19|20)\d\d)[- /.](?:(?:0[1-9]|1[0-2])[- /.](?:0[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])[- /.](?:29|30)|(?:0[13578]|1[02])-31)$", mojiStr, "<say-as interpret-as=\"date\" format=\"ymd\">", "</say-as>");
                        //變更時間讀法
                        mojiStr = toSSLMrule(@"^(1[0-2]|0?[1-9]|2[0-3]):[0-5][0-9](?:am|pm)?$", mojiStr, "<say-as interpret-as=\"time\" format=\"hms12\">", "</say-as>");
                        fr2.UpdateprogressBar(65, MsgArr[2]);
                        string[] mojiStrArr = mojiStr.Split('\n');
                        
                        var pb = new PromptBuilder();
                        pb.StartVoice(Iuuma?.TrimStart());
                        pb.AppendSsmlMarkup("<prosody pitch=\"low\" range=\"high\" rate=\"medium\" duration=\"3000ms\" volume=\"87\">");
                        foreach (string item in mojiStrArr)
                        {
                            pb.AppendSsmlMarkup(toSSLMparagraph('p', item, MsgArr[5]));
                        }
                        pb.AppendSsmlMarkup("</prosody>");
                        fr2.UpdateprogressBar(95, MsgArr[3]);
                        pb.EndVoice();
                        RunVoice.Speak(pb);
                    }
                    else
                    {
                        //標準模式
                        RunVoice.SelectVoice(Iuuma?.TrimStart());
                        //分段讀取(改僅呈現進度條，以區別兩種模式)
                        string[] mojiStrArr = mojiStr.Split(new char[] { '\n', '。', '.' });
                        for (int r = 0; r < mojiStrArr.Length; r++)
                        {
                            fr2.UpdateprogressBar((int)((double)(r + 1) / mojiStrArr.Length * 100), MsgArr[2]);
                        }
                        RunVoice.Speak(mojiStr);
                    }
                    fr2.UpdateprogressBar(95, MsgArr[3]);
                    if (FileType != "─")
                    {
                        RunVoice.SetOutputToNull();
                        MessageBox.Show(MsgArr[4]);
                    }
                }
                fr2.UpdateprogressBar(100, MsgArr[3]);
            });
        }

        /// <summary>
        /// 解析內容加上段落和尾音變化 (遞迴)
        /// </summary>
        /// <param name="PaergraphType">段落或句子</param>
        /// <param name="TextStr">文字內容</param>
        /// <returns>整理完的SSML</returns>
        private string toSSLMparagraph(char PaergraphType,string TextStr,string lang)
        {
            if (PaergraphType == 'p')
            {
                string[] TextStrsArr = Regex.Split(TextStr, "(?<=[。!?！？~～－])");
                StringBuilder sb = new StringBuilder();
                foreach (string sItem in TextStrsArr)
                {
                    sb.Append(toSSLMparagraph('s', sItem, lang));
                }
                return $"<p xml:lang=\"{lang}\">{sb}</p>";
            }
            else if (PaergraphType == 's')
            {
                if (TextStr.Length > 4)
                {
                    string LastMoji = TextStr.Substring(TextStr.Length - 2);
                    switch (TextStr.Substring(TextStr.Length - 1))
                    {
                        case "。":
                            TextStr = $"<prosody pitch=\"medium\" rate=\"0.85\" volume=\"+8\"><emphasis level=\"moderate\">{TextStr}</emphasis></prosody><break time=\"300ms\" />";
                            break;
                        case "?":
                            if (LastMoji != ">!") TextStr = $"{TextStr.Substring(0, TextStr.Length - 2)}<prosody pitch=\"+4st\" rate=\"0.7\" volume=\"+8\">{LastMoji}</prosody>";
                            break;
                        case "？":
                            if (LastMoji != ">!") TextStr = $"{TextStr.Substring(0, TextStr.Length - 2)}<prosody pitch=\"+4st\" rate=\"0.8\" volume=\"+8\">{LastMoji}</prosody>";
                            break;
                        case "!":
                            if (LastMoji != ">!") TextStr = $"{TextStr.Substring(0, TextStr.Length - 2)}<prosody pitch=\"-2st\" rate=\"1.3\">{LastMoji}</prosody>";
                            TextStr = $"<prosody pitch=\"low\" rate=\"0.8\" volume=\"+13\">{TextStr}</prosody>";
                            break;
                        case "！":
                            if (LastMoji != ">！") TextStr =  $"{TextStr.Substring(0, TextStr.Length - 2)}<prosody pitch=\"-2st\" rate=\"1.3\">{LastMoji}</prosody>";
                            TextStr = $"<prosody pitch=\"low\" rate=\"0.8\" volume=\"+13\">{TextStr}</prosody>";
                            break;
                        case "~":
                            if (LastMoji != ">~") TextStr = $"{TextStr.Substring(0, TextStr.Length - 2)}<prosody pitch=\"+4st\" rate=\"0.55\" volume=\"+12\">{LastMoji}</prosody>";
                            break;
                        case "～":
                            if (LastMoji != ">～") TextStr =  $"{TextStr.Substring(0, TextStr.Length - 2)}<prosody pitch=\"+4st\" rate=\"0.5\" volume=\"+12\">{LastMoji}</prosody>";
                            break;
                        case "—":
                            if (LastMoji != ">－") TextStr =  $"{TextStr.Substring(0, TextStr.Length - 2)}<prosody pitch=\"-6st\" rate=\"0.5\">{LastMoji}</prosody>";
                            TextStr = $"<prosody pitch=\"low\" rate=\"0.9\" volume=\"+5\">{TextStr}</prosody>";
                            break;
                        default:
                            break;
                    }
                }
                return $"<s xml:lang=\"{lang}\">{TextStr}</s>";
            }
            else { 
                return TextStr;
            }  
        }

        private string toSSLMrule(string ReRule, string TextStr, string ReTagS,string ReTagE)
        {
            MatchCollection matches = Regex.Matches(TextStr, ReRule);
            foreach (Match match in matches)
            {
                TextStr = TextStr.Replace(match.Value, $"{ReTagS}{match.Value}{ReTagE}");
            }
            return TextStr;
        }
    }
}
