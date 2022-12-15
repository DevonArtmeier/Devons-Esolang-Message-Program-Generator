namespace EsolangMsgGen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cbLanguage.SelectedIndex = 0;
        }

        private void UpdateGenProgram(object sender, EventArgs e)
        {
            string msg = tbMessage.Text.Replace("\r\n", "\n");
            switch (cbLanguage.SelectedIndex)
            {
                case 0:
                    tbOutput.Text = Brainfk.Generate(msg);
                    break;

                case 1:
                    tbOutput.Text = Boolfk.Generate(msg);
                    break;

                case 2:
                    tbOutput.Text = Whitespace.Generate(msg);
                    break;

                case 3:
                    tbOutput.Text = LOLCODE.Generate(msg);
                    break;
            }
        }
    }
}