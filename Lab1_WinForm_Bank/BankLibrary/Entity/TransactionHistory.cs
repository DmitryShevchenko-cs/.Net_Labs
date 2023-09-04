namespace BankLibrary;

public class TransactionHistory
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
    public string? Action { get; set; }
}