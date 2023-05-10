namespace TextSpeechKT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            comboBox1 = new ComboBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Font = new Font("微軟正黑體", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(823, 435);
            button1.Name = "button1";
            button1.Size = new Size(193, 87);
            button1.TabIndex = 0;
            button1.Text = "轉換";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(118, 27);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(357, 94);
            listBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(34, 149);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(758, 373);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 27);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "輸出語言";
            // 
            // button3
            // 
            button3.BackColor = Color.RoyalBlue;
            button3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(854, 13);
            button3.Name = "button3";
            button3.Size = new Size(82, 43);
            button3.TabIndex = 5;
            button3.Text = "中文介面";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GradientInactiveCaption;
            button4.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(930, 13);
            button4.Name = "button4";
            button4.Size = new Size(86, 43);
            button4.TabIndex = 6;
            button4.Text = "日本語インタフェース";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(528, 27);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 7;
            label2.Text = "您的OS語言為：";
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 127);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(799, 412);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "文字輸入框";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(21, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(73, 19);
            radioButton1.TabIndex = 9;
            radioButton1.Text = "標準模式";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(21, 58);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(73, 19);
            radioButton2.TabIndex = 10;
            radioButton2.TabStop = true;
            radioButton2.Text = "調整模式";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "─", ".MP3", ".MP4", ".AVI", ".WMV" });
            comboBox1.Location = new Point(79, 100);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(108, 27);
            comboBox1.TabIndex = 11;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(radioButton2);
            groupBox2.Location = new Point(823, 245);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(193, 152);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "選項";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 106);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 12;
            label3.Text = "OutputFile";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(976, 541);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 13;
            label4.Text = "v1.1.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 565);
            Controls.Add(label4);
            Controls.Add(groupBox2);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "語音轉文字winAP";
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private TextBox textBox1;
        private Label label1;
        private Button button3;
        private Button button4;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
    }
}