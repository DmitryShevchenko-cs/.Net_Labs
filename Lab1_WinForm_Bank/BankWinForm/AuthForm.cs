using BankLibrary.Services;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BankWinForm
{
    public partial class AuthForm : Form
    {
        private MainForm mForm;
        public static string CardNumber;
        public static string CVV;
        public static string Expirydate;
        public static string PinCode;
        public BankService bankService;


        public AuthForm()
        {
            InitializeComponent();
            bankService = new BankService();
            textBox4.PasswordChar = '*';
        }



        private async void button1_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;

            AuthForm.CardNumber = textBox1.Text;
            AuthForm.CVV = textBox3.Text;
            AuthForm.Expirydate = textBox2.Text;
            AuthForm.PinCode = textBox4.Text;

            if (DateTime.TryParseExact(AuthForm.Expirydate, "MM/yy", null, System.Globalization.DateTimeStyles.None,
                    out DateTime result))
            {
                var user = await bankService.AuthorizeAsync(AuthForm.CardNumber, AuthForm.CVV, result, AuthForm.PinCode);
                if (user is not null)
                {
                    Account.Login(user);
                    MainForm mainForm = new MainForm();

                    mainForm.Show();

                    mainForm.FormClosed += (s, args) => this.Show();

                    this.Hide();
                }

            }







        }
    }
}