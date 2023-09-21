using BankLibrary;
using BankLibrary.Services;

namespace BankWinForm
{
    public partial class MainForm : Form
    {
        private InputForm _inpForm;
        private BankService _bankService;
        private TransactionHistoryService _transactionHistoryService;
        private AtmService _atmService;
        private int _atmNumber;

        public MainForm()
        {
            InitializeComponent();
            _bankService = new BankService();
            _transactionHistoryService = new TransactionHistoryService();
            _atmNumber = new Random().Next(1, 10);
            _atmService = new AtmService();
        }
        private async void ShowBalance_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = (await _bankService.CheckBalanceAsync(Account.user.Id)).ToString();
        }

        private async void ShowHistory_Click(object sender, EventArgs e)
        {          
            this.textBox1.Text = "";
            _inpForm = new InputForm();
            this.Hide();
            _inpForm.textBox1.Visible = false;
            _inpForm.comboBox1.Visible = true;
            _inpForm.Show();

            _inpForm.FormClosed += async (s, args) =>
            {
                if (_inpForm.DialogResult == DialogResult.OK)
                {
                    var input = _inpForm.comboBox1.SelectedIndex.ToString();
                    
                    var history = _transactionHistoryService
                        .ToString(await _bankService.CheckHistoryAsync(Account.user!.Id, Enum.Parse<HistorySize>(input)));

                    var historyList = history.Split("\n");
                    foreach (var hist in historyList)
                    {
                        this.textBox1.Text += hist + Environment.NewLine;
                    }

                }
                this.Show();
            };
        }

        private void GetMoney_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            _inpForm = new InputForm();
            this.Hide();
            _inpForm.textBox1.PlaceholderText = "Money amount";
            _inpForm.Show();

            _inpForm.FormClosed += async (s, args) =>
            {
                string inputText;
                if (_inpForm.DialogResult == DialogResult.OK)
                {

                    inputText = _inpForm.textBox1.Text;
                    if (! await _bankService.GetMoneyAsync(Account.user.Id, int.Parse(inputText), _atmNumber))
                    {
                        MessageBox.Show("Not enough money on the card");
                    }
                    
                }
                this.textBox1.Text = (await _bankService.CheckBalanceAsync(Account.user.Id)).ToString();
                this.Show();
            };
        }

        private void SetMoney_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            _inpForm = new InputForm();
            this.Hide();
            _inpForm.textBox1.PlaceholderText = "Money amount";
            _inpForm.Show();

            _inpForm.FormClosed += async (s, args) =>
            {
                string inputText;
                if (_inpForm.DialogResult == DialogResult.OK)
                {

                    inputText = _inpForm.textBox1.Text;
                    await _bankService.SetMoneyAsync(Account.user.Id, int.Parse(inputText), _atmNumber);

                }
                this.textBox1.Text = (await _bankService.CheckBalanceAsync(Account.user.Id)).ToString();
                this.Show();
            };
        }

        private async void SendMoney_ClickAsync(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            string card;
            string money;
                       
            _inpForm = new InputForm();
            this.Hide();
            _inpForm.textBox1.PlaceholderText = "Card number";
            _inpForm.ShowDialog();
            
            if (_inpForm.DialogResult == DialogResult.OK)
            {
                
                card = _inpForm.textBox1.Text;
                _inpForm = new InputForm();
                this.Hide();
                _inpForm.textBox1.PlaceholderText = "Money amount";
                _inpForm.ShowDialog();
                
                if (_inpForm.DialogResult == DialogResult.OK)
                {
                    
                    money = _inpForm.textBox1.Text;
                    if (! await _bankService.SendMoneyAsync(Account.user.Id, card, int.Parse(money), _atmNumber))
                    {
                        MessageBox.Show("Not enough money on the card");
                    }
                }

                this.textBox1.Text = (await _bankService.CheckBalanceAsync(Account.user.Id)).ToString();
                this.Show();
            }

        }

        private async void CheckATMs_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            string tempInp = "";
            _inpForm = new InputForm();
            this.Hide();

            _inpForm.Show();
            _inpForm.textBox1.PlaceholderText = "ATM Amount";
            _inpForm.FormClosed += async (s, args) =>
            {
                if (_inpForm.DialogResult == DialogResult.OK)
                {
                    var ATMs = _atmService.ToString(await _atmService.FindNearestATMs(_atmNumber, int.Parse(_inpForm.textBox1.Text))).Split("\n");
                    foreach (var atm in ATMs)
                    {
                        this.textBox1.Text += atm + Environment.NewLine;
                    }
                }
                this.Show();
            };
        }
    }
}
