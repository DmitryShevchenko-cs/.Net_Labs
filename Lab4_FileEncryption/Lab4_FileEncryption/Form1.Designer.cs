namespace Lab4_FileEncryption;

public partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    public System.ComponentModel.IContainer components = null;

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
    public void InitializeComponent()
    {
        textBox1 = new TextBox();
        button1 = new Button();
        openFileDialog1 = new OpenFileDialog();
        button2 = new Button();
        folderBrowserDialog1 = new FolderBrowserDialog();
        bw = new System.ComponentModel.BackgroundWorker();
        progressBar1 = new ProgressBar();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new Point(12, 12);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(243, 23);
        textBox1.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new Point(12, 54);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 1;
        button1.Text = "Encrypt";
        button1.UseVisualStyleBackColor = true;
        button1.Click += buttonEncrypt_Click;
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        openFileDialog1.Filter = "All Files (*.*)|*.*";
        openFileDialog1.InitialDirectory = "C:\\\\";
        // 
        // button2
        // 
        button2.Location = new Point(180, 54);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 2;
        button2.Text = "Decrypt";
        button2.UseVisualStyleBackColor = true;
        // 
        // bw
        // 
        bw.WorkerReportsProgress = true;
        bw.WorkerSupportsCancellation = true;
        bw.DoWork += bw_DoWork;
        bw.ProgressChanged += bw_ProgressChanged;
        // 
        // progressBar1
        // 
        progressBar1.Location = new Point(32, 234);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(382, 23);
        progressBar1.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(459, 278);
        Controls.Add(progressBar1);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Name = "Form1";
        Text = "Encrypt";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private Button button1;
    private OpenFileDialog openFileDialog1;
    private Button button2;
    private FolderBrowserDialog folderBrowserDialog1;
    public ProgressBar progressBar1;
    public static System.ComponentModel.BackgroundWorker bw;
}