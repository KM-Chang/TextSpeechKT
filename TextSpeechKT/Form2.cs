using System;

namespace TextSpeechKT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }
        public void UpdateprogressBar(int NowVal, string Msg)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() =>
                {
                    progressBar1.Value = NowVal;
                    this.Text = Msg;
                    if (NowVal >= 100) Dispose();
                }));
            }
            else
            {
                progressBar1.Value = NowVal;
                this.Text = Msg;
                if (NowVal >= 100) Dispose();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //不可關閉 若是使用者點擊關閉則取消該動作
                e.Cancel = true;
            }
        }
    }
}
