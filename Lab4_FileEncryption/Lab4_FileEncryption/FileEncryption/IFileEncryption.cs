using System.ComponentModel;

namespace Lab4.BL;

public interface IFileEncryption
{
    long EncryptFile(string inputFilePath, string outputFilePath, BackgroundWorker worker, DoWorkEventArgs e, ManualResetEvent pause, ThreadPriority threadPriority);
    long DecryptFile(string inputFilePath, string outputFilePath, BackgroundWorker worker, DoWorkEventArgs e,  ManualResetEvent pause, ThreadPriority threadPriority);
}