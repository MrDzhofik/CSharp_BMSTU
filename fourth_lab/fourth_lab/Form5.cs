﻿using System;
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
    public partial class Form5 : Form
    {
        private ProjectManager projectManager;
        public Form5(ProjectManager projectManager)
        {
            InitializeComponent();
            this.projectManager = projectManager;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string result = projectManager.DisplayAllTasks();
            richTextBox.Text = result;
        }
    }
}