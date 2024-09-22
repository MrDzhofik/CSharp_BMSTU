namespace fourth_lab
{
    public partial class Form1 : Form
    {

        ProjectManager projectManager = new ProjectManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(ref projectManager);
            newForm.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(ref projectManager);
            newForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AnalyticButton_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4(projectManager);
            newForm.Show();
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5(projectManager);
            newForm.Show();
        }
    }
}
