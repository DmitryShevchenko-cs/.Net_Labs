using BankLibrary;
using BankLibrary.Services;

namespace BankWinForm
{
    static class Account
    {
        public static User? user { get; set; }

        public static void Login(User user) => Account.user = user;

        public static void Logout() => user = null;

    }
}
