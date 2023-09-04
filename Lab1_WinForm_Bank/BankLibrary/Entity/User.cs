namespace BankLibrary;

public class User
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public BankCard BankCard { get; set; }
    public List<TransactionHistory> TransactionHistory { get; set; }
}