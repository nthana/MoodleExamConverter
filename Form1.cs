namespace MoodleExamConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var converter = new Converter();
            txtDest.Text = converter.Convert(txtSource.Text);
        }

        private void btnRemoveBlankLine_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A choice = a character + a dot + a space.\r\n" +
                "The correct answer should be marked with '*' at the beginning.\r\n" +
                "This program will generate the Moodle Multichoice format."
                , "How To Use & Format");
        }
    }
}