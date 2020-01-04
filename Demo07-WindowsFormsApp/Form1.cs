using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonGreet_Click(object sender, EventArgs e)
        {
            Greet();
        }

        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            EnableButton();

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // See takistab teate edasi saatmist teistele komponentidele
                Greet();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            EnableButton();
        }

        private void EnableButton()
        {
            string tekst = textBoxName.Text;

            buttonGreet.Enabled = !string.IsNullOrEmpty(tekst);
        }

        private void Greet()
        {
            string tekst = textBoxName.Text;

            if (string.IsNullOrEmpty(tekst))
            {
                errorProvider.SetError(textBoxName, "Palun sisesta oma nimi");
                return;
            }
            else
            {
                errorProvider.Clear();
            }

            string tervitus = $"Tere, {tekst}";

            textBoxLog.Text += $"{tervitus}{Environment.NewLine}";

            MessageBox.Show(tervitus, "Tervitus",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
