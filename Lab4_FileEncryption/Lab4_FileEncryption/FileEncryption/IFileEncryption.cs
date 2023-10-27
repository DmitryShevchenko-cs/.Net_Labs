namespace Lab4.BL;

public interface IFileEncryption
{
    Task EncryptFile(string inputFilePath, string outputFilePath);
    Task DecryptFile(string inputFilePath, string outputFilePath);
}