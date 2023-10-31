using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace Lab4_FileEncryption
{
    public partial class Encryption : Form
    {
        public Encryption()
        {
            InitializeComponent();
        }

        private readonly FileEncryption.FileEncryption _fileEncryption = new FileEncryption.FileEncryption();
        private string _inputFilePath = "";
        private string _outputFilePath = "";
        private ManualResetEvent _manualResetEvent = new(true);
        private readonly Stopwatch _stopwatch = new();
        private double _fileSize;
        private ThreadPriority _priority;

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxKey.Text))
            {
                MessageBox.Show("Text box is empty. Please enter your key");
            }
            else
            {
                _stopwatch.Reset();
                resultLabel.Text = String.Empty;
                _fileEncryption.Key = textBoxKey.Text;
                buttonEncrypt.Enabled = false;
                buttonDecrypt.Enabled = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _inputFilePath = openFileDialog1.FileName;
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        _outputFilePath = folderBrowserDialog1.SelectedPath + $@"\Encrypted_{openFileDialog1.SafeFileName}";
                    }
                }
                buttonCancel.Enabled = true;
                buttonStopResume.Enabled = true;
                timeLabel.Text = "";
                fileSizeLabel.Text = "";
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxKey.Text))
            {
                MessageBox.Show("Text box is empty. Please enter your key");
            }
            else
            {
                _stopwatch.Reset();
                resultLabel.Text = String.Empty;
                _fileEncryption.Key = textBoxKey.Text;
                buttonEncrypt.Enabled = false;
                buttonDecrypt.Enabled = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _inputFilePath = openFileDialog1.FileName;
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        _outputFilePath = folderBrowserDialog1.SelectedPath + $@"\Decrypted_{openFileDialog1.SafeFileName}";
                    }
                }
                buttonCancel.Enabled = true;
                buttonStopResume.Enabled = true;
                timeLabel.Text = "";
                fileSizeLabel.Text = "";
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            buttonCancel.Enabled = false;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _stopwatch.Start();
            var fileBytes =
                _fileEncryption.EncryptFile(_inputFilePath, _outputFilePath, backgroundWorker1, e, _manualResetEvent, _priority);
            _fileSize = (double)fileBytes / (1024 * 1024);
            _stopwatch.Stop();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            _stopwatch.Start();
            var fileBytes =
                _fileEncryption.DecryptFile(_inputFilePath, _outputFilePath, backgroundWorker2, e, _manualResetEvent, _priority);
            _fileSize = (double)fileBytes / (1024 * 1024);
            _stopwatch.Stop();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            resultLabel.Text = e.ProgressPercentage.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                resultLabel.Text = "Canceled";
            }
            else
            {
                resultLabel.Text = "Done";
                double elapsedSeconds = _stopwatch.Elapsed.TotalSeconds;
                timeLabel.Text = $"Spent time: {elapsedSeconds}s";
                fileSizeLabel.Text = $"File size: {Math.Round(_fileSize, 2)}mbs";
            }

            _inputFilePath = "";
            _outputFilePath = "";
            buttonCancel.Enabled = false;
            buttonEncrypt.Enabled = true;
            buttonDecrypt.Enabled = true;
            buttonStopResume.Enabled = false;
        }



        private void Encryption_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (_manualResetEvent.WaitOne(0))
            {
                _manualResetEvent.Reset();
                buttonStopResume.Text = "Resume";
                return;
            }

            buttonStopResume.Text = "Stop";
            _manualResetEvent.Set();
        }

        private void LowestPriority_CheckedChanged(object sender, EventArgs e)
        {
            _priority = ThreadPriority.Lowest;
        }

        private void NormalPriority_CheckedChanged(object sender, EventArgs e)
        {
            _priority = ThreadPriority.Normal;
        }

        private void HighestPriority_CheckedChanged(object sender, EventArgs e)
        {
            _priority = ThreadPriority.Highest;
        }
    }
}
