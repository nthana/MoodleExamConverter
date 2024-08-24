using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodleExamConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += " v." + GetVersion();
        }

        private string GetVersion()
        {
            // get version: https://stackoverflow.com/questions/6493715/how-to-get-the-current-product-version-in-c
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.FileVersion == null ? "" : fileVersionInfo.FileVersion.ToString();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var converter = new Converter();
            txtDest.Text = converter.Convert(txtSource.Text);
        }

        private void btnRemoveBlankLine_Click(object sender, EventArgs e)
        {
            // idea from : https://stackoverflow.com/questions/7647716/how-to-remove-empty-lines-from-a-formatted-string
            txtDest.Text = Regex.Replace(txtDest.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"1) Normal line: does not start with ""letter + dot + space"" (ex. ""a. "")
2) Choice line: starts with a letter + dot + space (ex. ""a. "")
A choice line can have more than one choice.

The correct answer should be marked with '*'. (ex. ""*a. "")

This program will generate the Moodle Multichoice format.
"
                , "How To Use & Format");
        }
    }
}