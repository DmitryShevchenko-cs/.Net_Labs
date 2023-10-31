namespace Lab4_FileEncryption
{
    partial class Encryption
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
            buttonEncrypt = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            textBoxKey = new TextBox();
            progressBar1 = new ProgressBar();
            buttonDecrypt = new Button();
            buttonCancel = new Button();
            resultLabel = new Label();
            buttonStopResume = new Button();
            timeLabel = new Label();
            fileSizeLabel = new Label();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            LowestPriority = new RadioButton();
            NormalPriority = new RadioButton();
            HighestPriority = new RadioButton();
            SuspendLayout();
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point(126, 41);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(75, 23);
            buttonEncrypt.TabIndex = 0;
            buttonEncrypt.Text = "Encrypt";
            buttonEncrypt.UseVisualStyleBackColor = true;
            buttonEncrypt.Click += buttonEncrypt_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(12, 12);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.PlaceholderText = "Enter Key";
            textBoxKey.Size = new Size(304, 23);
            textBoxKey.TabIndex = 3;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 217);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(297, 23);
            progressBar1.TabIndex = 1;
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Location = new Point(234, 41);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(75, 23);
            buttonDecrypt.TabIndex = 0;
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += buttonDecrypt_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(234, 70);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(12, 199);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(39, 15);
            resultLabel.TabIndex = 5;
            resultLabel.Text = "Result";
            // 
            // buttonStopResume
            // 
            buttonStopResume.Location = new Point(126, 70);
            buttonStopResume.Name = "buttonStopResume";
            buttonStopResume.Size = new Size(75, 23);
            buttonStopResume.TabIndex = 6;
            buttonStopResume.Text = "Stop";
            buttonStopResume.UseVisualStyleBackColor = true;
            buttonStopResume.Click += buttonStop_Click;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(12, 140);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(33, 15);
            timeLabel.TabIndex = 7;
            timeLabel.Text = "Time";
            // 
            // fileSizeLabel
            // 
            fileSizeLabel.AutoSize = true;
            fileSizeLabel.Location = new Point(12, 165);
            fileSizeLabel.Name = "fileSizeLabel";
            fileSizeLabel.Size = new Size(47, 15);
            fileSizeLabel.TabIndex = 8;
            fileSizeLabel.Text = "File size";
            // 
            // backgroundWorker2
            // 
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker2.DoWork += backgroundWorker2_DoWork;
            backgroundWorker2.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker2.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // LowestPriority
            // 
            LowestPriority.AutoSize = true;
            LowestPriority.Checked = true;
            LowestPriority.Location = new Point(12, 41);
            LowestPriority.Name = "LowestPriority";
            LowestPriority.Size = new Size(62, 19);
            LowestPriority.TabIndex = 9;
            LowestPriority.TabStop = true;
            LowestPriority.Text = "Lowest";
            LowestPriority.UseVisualStyleBackColor = true;
            LowestPriority.CheckedChanged += LowestPriority_CheckedChanged;
            // 
            // NormalPriority
            // 
            NormalPriority.AutoSize = true;
            NormalPriority.Location = new Point(13, 66);
            NormalPriority.Name = "NormalPriority";
            NormalPriority.Size = new Size(65, 19);
            NormalPriority.TabIndex = 9;
            NormalPriority.Text = "Normal";
            NormalPriority.UseVisualStyleBackColor = true;
            NormalPriority.CheckedChanged += NormalPriority_CheckedChanged;
            // 
            // HighestPriority
            // 
            HighestPriority.AutoSize = true;
            HighestPriority.Location = new Point(12, 91);
            HighestPriority.Name = "HighestPriority";
            HighestPriority.Size = new Size(66, 19);
            HighestPriority.TabIndex = 9;
            HighestPriority.Text = "Highest";
            HighestPriority.UseVisualStyleBackColor = true;
            HighestPriority.CheckedChanged += HighestPriority_CheckedChanged;
            // 
            // Encryption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 252);
            Controls.Add(HighestPriority);
            Controls.Add(NormalPriority);
            Controls.Add(LowestPriority);
            Controls.Add(fileSizeLabel);
            Controls.Add(timeLabel);
            Controls.Add(buttonStopResume);
            Controls.Add(resultLabel);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxKey);
            Controls.Add(progressBar1);
            Controls.Add(buttonDecrypt);
            Controls.Add(buttonEncrypt);
            Name = "Encryption";
            Text = "Encryption";
            Load += Encryption_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEncrypt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox textBoxKey;
        private ProgressBar progressBar1;
        private Button buttonDecrypt;
        private Button buttonCancel;
        private Label resultLabel;
        private Button buttonStopResume;
        private Label timeLabel;
        private Label fileSizeLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private RadioButton LowestPriority;
        private RadioButton NormalPriority;
        private RadioButton HighestPriority;
    }
}