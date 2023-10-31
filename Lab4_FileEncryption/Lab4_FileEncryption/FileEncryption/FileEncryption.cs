using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using Lab4.BL;

namespace Lab4_FileEncryption.FileEncryption;

public class FileEncryption : IFileEncryption
{
    public string Key { get; set; }

    public FileEncryption()
    {
    }

    public FileEncryption(string key)
    {
        Key = key;
    }

    public long EncryptFile(string inputFile, string outputFile, BackgroundWorker worker, DoWorkEventArgs e,
        ManualResetEvent pause, ThreadPriority threadPriority)
    {
        using RijndaelManaged rmCrypto = new RijndaelManaged();
        byte[] keyBytes = GetDerivedKey(Key, rmCrypto.KeySize);
        byte[] ivBytes = GetDerivedKey(Key, rmCrypto.BlockSize);
        Thread.CurrentThread.Priority = threadPriority;
        rmCrypto.Key = keyBytes;
        rmCrypto.IV = ivBytes;

        using (var fsSrc = new FileStream(inputFile, FileMode.Open))
        using (var aes = new AesManaged() { Key = keyBytes })
        using (var fsDst = new FileStream(outputFile, FileMode.Create))
        {
            fsDst.Write(ivBytes);
            using (var cs = new CryptoStream(fsDst, rmCrypto.CreateEncryptor(), CryptoStreamMode.Write, true))
            {
                byte[] buffer = new byte[50 * 1024];
                int bytesRead;
                long totalBytesRead = 0;
                while ((bytesRead = fsSrc.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (worker.IsBusy)
                    {
                        cs.Write(buffer, 0, bytesRead);
                        var progress = (int)(fsSrc.Position / (double)fsSrc.Length * 100);
                        totalBytesRead += bytesRead;
                        worker.ReportProgress(progress);
                        Console.WriteLine(progress);
                        pause.WaitOne();
                    }
                }

                return totalBytesRead;
            }
        }
    }


    public long DecryptFile(string inputFile, string outputFile, BackgroundWorker worker, DoWorkEventArgs e,
        ManualResetEvent pause, ThreadPriority threadPriority)
    {
        RijndaelManaged rmCrypto = new RijndaelManaged();
        byte[] keyBytes = GetDerivedKey(Key, rmCrypto.KeySize);
        byte[] ivBytes = GetDerivedKey(Key, rmCrypto.BlockSize);
        rmCrypto.Key = keyBytes;
        rmCrypto.IV = ivBytes;
        Thread.CurrentThread.Priority = threadPriority;
        using (FileStream fsSrc = new FileStream(inputFile, FileMode.Open))
        {
            byte[] iv = new byte[16];
            fsSrc.Read(iv);
            using (AesManaged aes = new AesManaged() { Key = keyBytes })
            using (CryptoStream cs = new CryptoStream(fsSrc, rmCrypto.CreateDecryptor(), CryptoStreamMode.Read))
            using (FileStream fsDst = new FileStream(outputFile, FileMode.Create))
            {
                byte[] buffer = new byte[50 * 1024];
                int bytesRead;

                long totalBytesRead = 0;
                while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (worker.IsBusy)
                    {
                        fsDst.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                        var progress = (int)((double)fsSrc.Position / fsSrc.Length * 100);
                        worker.ReportProgress(progress);
                        Console.WriteLine(progress);
                        pause.WaitOne();
                    }
                }

                return totalBytesRead;
            }
        }
    }

    private byte[] GetDerivedKey(string key, int keySize)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(keyBytes, new byte[8], 1000))
        {
            return deriveBytes.GetBytes(keySize / 8);
        }
    }
}