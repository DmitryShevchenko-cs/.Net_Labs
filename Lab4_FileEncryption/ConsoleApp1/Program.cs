

namespace ConsoleApp1;

public static class Program
{
    public static async Task Main()
    {
        //FileEncryption fileEncryption = new FileEncryption("123123");
        string projectDirectory1 = Directory.GetCurrentDirectory();
        string outputFilePath1 = Path.Combine(projectDirectory1, "Заш222.txt");
        //fileEncryption.EncryptFile(inputFile: @"C:\Users\Dmitry\Desktop\Текстовый документ.txt", outputFile: outputFilePath1);
        
        string projectDirectory2 = Directory.GetCurrentDirectory();
        string inputFilePath2 = Path.Combine(projectDirectory2, "Заш222.txt");
        string outputFilePath2 = Path.Combine(projectDirectory2, "Раз222.txt");
        
        //fileEncryption.DecryptFile(inputFile: inputFilePath2, outputFile: outputFilePath2);
        
        
    }
}
