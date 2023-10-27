using System.Security.Cryptography;
using System.Text;
using Lab4.BL;

namespace Lab4_FileEncryption.FileEncryption;

public class FileEncryption : IFileEncryption {
    public string Key { get; set; }

    public FileEncryption()
    {
    }
    public FileEncryption(string key)
    {
        Key = key;
    }

    public async Task EncryptFile(string inputFile, string outputFile)
    {
        using RijndaelManaged rmCrypto = new RijndaelManaged();
        byte[] keyBytes = GetDerivedKey(Key, rmCrypto.KeySize);
        byte[] ivBytes = GetDerivedKey(Key, rmCrypto.BlockSize);

        rmCrypto.Key = keyBytes;
        rmCrypto.IV = ivBytes;

        await using FileStream fsCrypt = new FileStream(outputFile, FileMode.Create);
        await using CryptoStream cs = new CryptoStream(fsCrypt, rmCrypto.CreateEncryptor(), CryptoStreamMode.Write);
        await using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
        {
            int data;
            int totalBytesRead = 0;
            var totalSize = fsIn.Length;
                        
            while ((data = fsIn.ReadByte()) != -1)
            {
                cs.WriteByte((byte)data);
                totalBytesRead ++;
                int pr = (int)((double)totalBytesRead / totalSize * 100);
                Form1.bw.ReportProgress(pr);
            }
        }
    }

    public async Task DecryptFile(string inputFile, string outputFile)
    {
        using (RijndaelManaged rmCrypto = new RijndaelManaged())
        {
            byte[] keyBytes = GetDerivedKey(Key, rmCrypto.KeySize);
            byte[] ivBytes = GetDerivedKey(Key, rmCrypto.BlockSize);

            rmCrypto.Key = keyBytes;
            rmCrypto.IV = ivBytes;

            using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
            {
                using (CryptoStream cs = new CryptoStream(fsCrypt, rmCrypto.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                    {
                        int data;
                        int totalBytesRead = 0;
                        var totalSize = fsOut.Length;
                        while ((data = cs.ReadByte()) != -1)
                        {
                            fsOut.WriteByte((byte)data);
                            totalBytesRead ++;
                            int pr = (int)((double)totalBytesRead / totalSize * 100);
                            Form1.bw.ReportProgress(pr);
                        }
                    }
                }
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