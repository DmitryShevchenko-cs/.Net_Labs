namespace BankLibrary;

public class TransactionHistory
{
    public int Id { get; set; }
    public int BankCardId { get; set; }
    public BankCard? BankCard { get; set; }
    
    public string? Action { get; set; }

    public DateTime DateTime { get; set; }
}