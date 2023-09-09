using BankLibrary;
using BankLibrary.Services;

namespace BankConsole
{
    class Bank
    {
        static async Task Main()
        {
            var bankService = new BankService();
            var userService = new UserService();

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
                
                if (DateTime.TryParseExact(expDate, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    var user = await bankService.AuthorizeAsync(cardNumber!, cvv!, result, pinCode!);
                    while (!exit)
                    {
                        //auth  +
                        //check balance + 
                            //check history
                        //get money +
                        //set money +
                        //send money +
                            //check bank boxes
                        
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
                                //////////
                                Console.WriteLine($"Balance: {user!.BankCard.TransactionHistory}");
                                break;

                            case "3":
                                Console.Clear();
                                Console.WriteLine("Money");
                                string money = Console.ReadLine();
                                await bankService.GetMoneyAsync(user!.Id, decimal.Parse(money!));
                                break;
                            
                            case "4":
                                Console.Clear();
                                Console.WriteLine("Money");
                                money = Console.ReadLine();
                                await bankService.SetMoneyAsync(user!.Id, decimal.Parse(money!));
                                break;
                            
                            case "5":
                                Console.Clear();
                                Console.WriteLine("Money");
                                money = Console.ReadLine();
                                await bankService.SendMoneyAsync(user.Id, 3, decimal.Parse(money!));
                                break;
                            case "6":
                                //check bank boxes
                                break;

                            case "7":
                                Console.Clear();
                                Console.WriteLine("Выход из программы.");
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                                break;
                        }
                    }
                }
            }
        }

    }
}