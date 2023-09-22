using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankWinForm
{
    public partial class InputForm : Form
    {
        public static string InputText;

        public InputForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void Select_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            InputForm.InputText = textBox1.Text;

            this.Close();
        }
    }
}
