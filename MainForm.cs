namespace EsolangMsgGen
{
    public partial class MainForm : Form
    {
        delegate string Generate(string msg);
        Generate[] genFuncs = new Generate[]
        {
            Brainfk.Generate,
            Boolfk.Generate,
            Whitespace.Generate,
            LOLCODE.Generate,
            LoveLang.Generate
        };

        public MainForm()
        {
            InitializeComponent();
            cbLanguage.SelectedIndex = 0;
        }

        private void UpdateGenProgram(object sender, EventArgs e)
        {
            string msg = tbMessage.Text.Replace("\r\n", "\n");
            tbOutput.Text = genFuncs[cbLanguage.SelectedIndex](msg);
        }
    }
}