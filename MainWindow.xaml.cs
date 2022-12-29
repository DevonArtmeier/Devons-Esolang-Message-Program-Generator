using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EsolangMsgGenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

        public MainWindow()
        {
            InitializeComponent();
            Brainfk.GenOperations();
            cbLanguage.SelectedIndex = 0;
        }

        private void UpdateGenProgram(object sender, EventArgs e)
        {
            string msg = tbMessage.Text.Replace("\r\n", "\n");
            tbOutput.Text = genFuncs[cbLanguage.SelectedIndex](msg);
        }
    }
}
