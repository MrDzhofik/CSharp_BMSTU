namespace fourth_lab
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddLabel = new Label();
            AnalyticLabel = new Label();
            DateLabel = new Label();
            NameLabel = new Label();
            DescriptionLabel = new Label();
            NameBox = new TextBox();
            DescriptionBox = new TextBox();
            AnalyticBox = new TextBox();
            DateBox = new TextBox();
            ExitButton = new Button();
            AddButton = new Button();
            SuspendLayout();
            // 
            // AddLabel
            // 
            AddLabel.AutoSize = true;
            AddLabel.Font = new Font("Segoe UI", 14F);
            AddLabel.Location = new Point(246, 26);
            AddLabel.Name = "AddLabel";
            AddLabel.Size = new Size(234, 32);
            AddLabel.TabIndex = 0;
            AddLabel.Text = "Добавление задачи";
            // 
            // AnalyticLabel
            // 
            AnalyticLabel.AutoSize = true;
            AnalyticLabel.Font = new Font("Segoe UI", 14F);
            AnalyticLabel.Location = new Point(103, 245);
            AnalyticLabel.Name = "AnalyticLabel";
            AnalyticLabel.Size = new Size(181, 32);
            AnalyticLabel.TabIndex = 1;
            AnalyticLabel.Text = "Имя аналитика";
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Font = new Font("Segoe UI", 14F);
            DateLabel.Location = new Point(103, 309);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(152, 32);
            DateLabel.TabIndex = 2;
            DateLabel.Text = "Срок задачи";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 14F);
            NameLabel.Location = new Point(103, 114);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(203, 32);
            NameLabel.TabIndex = 3;
            NameLabel.Text = "Название задачи";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Font = new Font("Segoe UI", 14F);
            DescriptionLabel.Location = new Point(103, 177);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(207, 32);
            DescriptionLabel.TabIndex = 4;
            DescriptionLabel.Text = "Описание задачи";
            // 
            // NameBox
            // 
            NameBox.Font = new Font("Segoe UI", 14F);
            NameBox.Location = new Point(315, 114);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(302, 39);
            NameBox.TabIndex = 5;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Font = new Font("Segoe UI", 14F);
            DescriptionBox.Location = new Point(315, 177);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(302, 39);
            DescriptionBox.TabIndex = 6;
            // 
            // AnalyticBox
            // 
            AnalyticBox.Font = new Font("Segoe UI", 14F);
            AnalyticBox.Location = new Point(315, 245);
            AnalyticBox.Name = "AnalyticBox";
            AnalyticBox.Size = new Size(302, 39);
            AnalyticBox.TabIndex = 7;
            // 
            // DateBox
            // 
            DateBox.Font = new Font("Segoe UI", 14F);
            DateBox.Location = new Point(315, 309);
            DateBox.Name = "DateBox";
            DateBox.Size = new Size(302, 39);
            DateBox.TabIndex = 8;
            // 
            // ExitButton
            // 
            ExitButton.Font = new Font("Segoe UI", 14F);
            ExitButton.Location = new Point(651, 393);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(143, 45);
            ExitButton.TabIndex = 9;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // AddButton
            // 
            AddButton.Font = new Font("Segoe UI", 14F);
            AddButton.Location = new Point(502, 393);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(143, 45);
            AddButton.TabIndex = 10;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddButton);
            Controls.Add(ExitButton);
            Controls.Add(DateBox);
            Controls.Add(AnalyticBox);
            Controls.Add(DescriptionBox);
            Controls.Add(NameBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(NameLabel);
            Controls.Add(DateLabel);
            Controls.Add(AnalyticLabel);
            Controls.Add(AddLabel);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddLabel;
        private Label AnalyticLabel;
        private Label DateLabel;
        private Label NameLabel;
        private Label DescriptionLabel;
        private TextBox NameBox;
        private TextBox DescriptionBox;
        private TextBox AnalyticBox;
        private TextBox DateBox;
        private Button ExitButton;
        private Button AddButton;
    }
}