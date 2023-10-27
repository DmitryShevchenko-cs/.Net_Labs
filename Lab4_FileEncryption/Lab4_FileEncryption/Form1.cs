using Lab4.BL;
using System.Windows.Forms;
using System.Threading;

namespace Lab4_FileEncryption;

public partial class Form1 : Form
{

    private readonly FileEncryption.FileEncryption _fileEncryption = new FileEncryption.FileEncryption();

    public Form1()
    {
        InitializeComponent();
    }
    string inputFilePath = "";
    string outputFilePath = "";
    private void buttonEncrypt_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBox1.Text))
        {
            MessageBox.Show("Text box is empty. Please enter your key");
        }
        else
        {
            _fileEncryption.Key = textBox1.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFilePath = openFileDialog1.FileName;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFilePath = folderBrowserDialog1.SelectedPath + $@"\Encrypted_{openFileDialog1.SafeFileName}";
            }
        }
        
        bw.RunWorkerAsync();
    }

    private void bw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }

    private async void bw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        if (inputFilePath != "" && outputFilePath != "")
        {
            await Task.Run(() =>
            {
                _fileEncryption.EncryptFile(inputFilePath, outputFilePath);
            });
        }
    }
    
    

}