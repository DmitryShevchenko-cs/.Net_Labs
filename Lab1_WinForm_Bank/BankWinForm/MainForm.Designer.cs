namespace BankWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button7 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(24, 49);
            button1.Name = "button1";
            button1.Size = new Size(94, 59);
            button1.TabIndex = 1;
            button1.Text = "Show balance";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ShowBalance_Click;
            // 
            // button2
            // 
            button2.Location = new Point(24, 127);
            button2.Name = "button2";
            button2.Size = new Size(94, 59);
            button2.TabIndex = 2;
            button2.Text = "Show history";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ShowHistory_Click;
            // 
            // button3
            // 
            button3.Location = new Point(24, 206);
            button3.Name = "button3";
            button3.Size = new Size(94, 59);
            button3.TabIndex = 3;
            button3.Text = "Check nearest ATM";
            button3.UseVisualStyleBackColor = true;
            button3.Click += CheckATMs_Click;
            // 
            // button7
            // 
            button7.Location = new Point(556, 206);
            button7.Name = "button7";
            button7.Size = new Size(94, 59);
            button7.TabIndex = 6;
            button7.Text = "Send money";
            button7.UseVisualStyleBackColor = true;
            button7.Click += SendMoney_ClickAsync;
            // 
            // button4
            // 
            button4.Location = new Point(556, 127);
            button4.Name = "button4";
            button4.Size = new Size(94, 59);
            button4.TabIndex = 5;
            button4.Text = "Set money";
            button4.UseVisualStyleBackColor = true;
            button4.Click += SetMoney_Click;
            // 
            // button5
            // 
            button5.Location = new Point(556, 49);
            button5.Name = "button5";
            button5.Size = new Size(94, 59);
            button5.TabIndex = 4;
            button5.Text = "Get money";
            button5.UseVisualStyleBackColor = true;
            button5.Click += GetMoney_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaption;
            textBox1.Location = new Point(124, 49);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(426, 216);
            textBox1.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 300);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button7);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button7;
        private Button button4;
        private Button button5;
        private TextBox textBox1;
    }
}