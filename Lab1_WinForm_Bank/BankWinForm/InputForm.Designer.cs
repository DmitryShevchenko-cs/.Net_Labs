﻿namespace BankWinForm
{
    partial class InputForm
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
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            printDialog1 = new PrintDialog();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(135, 136);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Select_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(81, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 23);
            textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "DAY", "WEEK", "MONTH", "YEAR" });
            comboBox1.Location = new Point(109, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            comboBox1.Visible = false;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 197);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "InputForm";
            Text = "InputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        public TextBox textBox1;
        public ComboBox comboBox1;
        private PrintDialog printDialog1;
    }
}