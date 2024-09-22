using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fourth_lab
{
    public partial class Form2 : Form
    {

        private ProjectManager projectManager;
        public Form2(ref ProjectManager projectManager)
        {
            InitializeComponent();
            this.projectManager = projectManager;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string task = NameBox.Text;
            string description = DescriptionBox.Text;
            string name = AnalyticBox.Text;
            string date = DateBox.Text;

            projectManager.AddTask(task, description, name, date);

            NameBox.Text = "Записано!";
            DescriptionBox.Clear();
            AnalyticBox.Clear();
            DateBox.Clear();
        }
    }
}
