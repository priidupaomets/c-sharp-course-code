namespace WinFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTervita_Click(object sender, EventArgs e)
        {
            string nimi = textBoxNimi.Text;

            if (string.IsNullOrEmpty(nimi))
            {
                MessageBox.Show("Palun sisesta oma nimi!", "Oot-oot",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MessageBox.Show($"Tere tulemast, {nimi}", "Tervitus", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}