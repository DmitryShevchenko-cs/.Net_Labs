namespace BankLibrary.Helpers;

public class RandNumberHelper
{
    static Random random = new Random();

    public static string GenerateRandomCardNumber()
    {
        string cardNumber = "4";
        for (int i = 0; i < 15; i++)
        {
            int digit = random.Next(10); 
            cardNumber += digit.ToString();
        }
        return cardNumber;
    }

    
    public static string GenerateRandomCvv()
    {
        int cvvLength = 3; 
        string cvv = "";
        for (int i = 0; i < cvvLength; i++)
        {
            int digit = random.Next(10); 
            cvv += digit.ToString();
        }
        return cvv;
    }
}
