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
    public partial class Form3 : Form
    {

        public ProjectManager projectManager;
        public Form3(ref ProjectManager projectManager)
        {
            InitializeComponent();
            this.projectManager = projectManager;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string status = StatusTextBox.Text;

            projectManager.UpdateTaskStatus(name, status);

            NameTextBox.Text = "Статус изменен!";
            StatusTextBox.Clear();
        }
    }
}
