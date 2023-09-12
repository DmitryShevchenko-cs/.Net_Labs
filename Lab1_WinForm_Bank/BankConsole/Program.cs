using BankLibrary;
using BankLibrary.Services;
namespace BankConsole;

public static class Bank
{
    public static async Task Main()
    {
        Random random = new Random();
        var atmNumber = random.Next(1, 10);
        
        var bankService = new BankService();
        var userService = new UserService();
        var transactionHistoryService = new TransactionHistoryService();
        var atmService = new AtmService();

        // await userService.CreateUserAsync(new User
        // {
        //     Name = "John",
        //     Surname = "Boy",
        //     Email = "John.Boy@gmail.com"
        // });
        //
        // var userDb = await userService.GetByEmail("John.Boy@gmail.com");
        // await userService.AddBankCardAsync(userDb.Id, "1234");


        while (true)
        {

            Console.Clear();
            bool exit = false;
            Console.WriteLine("Card number");
            string cardNumber = Console.ReadLine();
            Console.WriteLine("CVV");
            string cvv = Console.ReadLine();
            Console.WriteLine("Expire date");
            string expDate = Console.ReadLine();
            Console.WriteLine("Pin code");
            string pinCode = Console.ReadLine();

            if (DateTime.TryParseExact(expDate, "MM/yy", null, System.Globalization.DateTimeStyles.None,
                    out DateTime result))
            {
                var user = await bankService.AuthorizeAsync(cardNumber!, cvv!, result, pinCode!);
                while (!exit)
                {
                    Console.WriteLine("Choose action:");
                    Console.WriteLine("1. check balance");
                    Console.WriteLine("2. check history");
                    Console.WriteLine("3. get money");
                    Console.WriteLine("4. set money");
                    Console.WriteLine("5. send money");
                    Console.WriteLine("6. check bank boxes");
                    Console.WriteLine("7. exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine($"Balance: {user!.BankCard.Balance}");
                            break;

                        case "2":
                            Console.Clear();
                            var history =
                                transactionHistoryService.ToString(
                                    await bankService.CheckHistoryAsync(user!.Id, HistorySize.YEAR));
                            Console.WriteLine($"Transaction history: \n{history}");
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Amount of money");
                            string money = Console.ReadLine();
                            await bankService.GetMoneyAsync(user!.Id, decimal.Parse(money!), atmNumber);
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Amount of money");
                            money = Console.ReadLine();
                            await bankService.SetMoneyAsync(user!.Id, decimal.Parse(money!), atmNumber);
                            break;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("Amount of money");
                            money = Console.ReadLine();
                            Console.WriteLine("Receiver card number");
                            cardNumber = Console.ReadLine();
                            await bankService.SendMoneyAsync(user.Id, cardNumber, decimal.Parse(money!), atmNumber);
                            break;
                        case "6":
                            Console.Clear();
                            Console.WriteLine("Count of nearest ATMs");
                            var count = Console.ReadLine();
                            Console.WriteLine(
                                atmService.ToString(
                                    await atmService.FindNearestATMs(atmNumber, int.Parse(count))));
                            break;

                        case "7":
                            Console.Clear();
                            Console.WriteLine("Выход из программы.");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Incorrect choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}