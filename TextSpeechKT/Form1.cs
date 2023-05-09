using Autofac;
using Autofac.Core;
using Microsoft.VisualBasic;
using System;
using System.Speech.Synthesis;
using System.Windows.Forms.Design;
using TextSpeechKT.Server;
namespace TextSpeechKT
{
    public partial class Form1 : Form
    {
        private readonly IConvertVoice _ConvertVoice;
        private string[] MsgArr = { "沒有任何內容", "排入序列", "語音產生中", "執行完成", "已匯出檔案至" };
        public Form1(IConvertVoice Fr1ConvertVoice)
        {
            InitializeComponent();
            //DI相依注入
            _ConvertVoice = Fr1ConvertVoice;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 獲取當前系統顯示的語言
            InputLanguage currentLanguage = InputLanguage.CurrentInputLanguage;
            label2.Text += $"{currentLanguage.Culture.DisplayName}\n(Language Code: {currentLanguage.Culture.LCID})";
            //取出目前OS安裝的合成語音包
            _ConvertVoice.GetLanguageList()
                .ForEach((v) =>
                {
                    listBox1.Items.Add($"{v.VoiceInfo.Culture.DisplayName.PadRight(6, ' ')}  | {v.VoiceInfo.Name}");
                });
            listBox1.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            //設定介面語言
            ChUiLang(currentLanguage.Culture.Name);
            if (!Directory.Exists("outFile")) Directory.CreateDirectory("outFile");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ConvertVoice.ToVoice((listBox1.SelectedItem ?? listBox1.Items[0])?.ToString()?.Split("|")[1], comboBox1.SelectedItem.ToString()
            , radioButton2.Checked, textBox1.Text, MsgArr);
            //System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChUiLang("zh-TW");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChUiLang("ja-JP");
        }

        private void ChUiLang(string LangStr)
        {
            #region 設定介面文字
            if (LangStr == "ja-JP")
            {
                button3.BackColor = SystemColors.GradientInactiveCaption;
                button3.ForeColor = Color.Black;
                button4.BackColor = Color.RoyalBlue;
                button4.ForeColor = SystemColors.ButtonFace;
                label1.Text = "アウトプット\n語言";
                label2.Text = label2.Text.Replace("您的OS語言為", "君のOS言語");
                groupBox1.Text = "文字入力";
                groupBox2.Text = "オプション";
                radioButton1.Text = "標準モード";
                radioButton2.Text = "自然モード";
                button1.Text = "変換する";
                if (textBox1.Text == "" || (textBox1.Text.Length > 3 && textBox1.Text[..3] == "您好！"))
                    textBox1.Text = "こんにちは！\r\nこれは文字を声に変換できるプログラミングですよ！\r\nこちらに內容を変わってみてください";

                MsgArr[0] = "內容は何もないです";
                MsgArr[1] = "順番処理します";
                MsgArr[2] = "音声合成します";
                MsgArr[3] = "執行完了";
                MsgArr[4] = "音声ファイルをOutFileというフォルダにエクスポートしました！";
            }
            else
            {
                button3.BackColor = Color.RoyalBlue;
                button3.ForeColor = SystemColors.ButtonFace;
                button4.BackColor = SystemColors.GradientInactiveCaption;
                button4.ForeColor = Color.Black;
                label1.Text = "輸出語言";
                label2.Text = label2.Text.Replace("君のOS言語", "您的OS語言為");
                groupBox1.Text = "文字輸入框";
                groupBox2.Text = "選項";
                radioButton1.Text = "標準模式";
                radioButton2.Text = "自然模式";
                button1.Text = "轉換";
                if (textBox1.Text == "" || (textBox1.Text.Length > 6 && textBox1.Text[..6] == "こんにちは！"))
                    textBox1.Text = "您好！\r\n這是一個文字轉換為語音合成的程式\r\n請嘗試在此變更文字內容";

                MsgArr[0] = "沒有任何內容";
                MsgArr[1] = "排入序列";
                MsgArr[2] = "語音產生中";
                MsgArr[3] = "執行完成";
                MsgArr[4] = "已匯出檔案至OutFile資料夾！";
            }
            #endregion
        }
    }
}