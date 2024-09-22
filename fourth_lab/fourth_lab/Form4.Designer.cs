namespace fourth_lab
{
    partial class Form4
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
            ExitButton = new Button();
            NameLabel = new Label();
            ResultLabel = new Label();
            NameTextBox = new TextBox();
            SearchButton = new Button();
            richTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Font = new Font("Segoe UI", 14F);
            ExitButton.Location = new Point(677, 386);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(111, 52);
            ExitButton.TabIndex = 1;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 14F);
            NameLabel.Location = new Point(105, 69);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(274, 32);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "Введите имя аналитика";
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI", 14F);
            ResultLabel.Location = new Point(105, 150);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(132, 32);
            ResultLabel.TabIndex = 3;
            ResultLabel.Text = "Его задачи";
            // 
            // NameTextBox
            // 
            NameTextBox.Font = new Font("Segoe UI", 14F);
            NameTextBox.Location = new Point(385, 69);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(231, 39);
            NameTextBox.TabIndex = 4;
            // 
            // SearchButton
            // 
            SearchButton.Font = new Font("Segoe UI", 14F);
            SearchButton.Location = new Point(560, 386);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(111, 52);
            SearchButton.TabIndex = 5;
            SearchButton.Text = "Найти";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(243, 156);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(373, 188);
            richTextBox.TabIndex = 6;
            richTextBox.Text = "";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox);
            Controls.Add(SearchButton);
            Controls.Add(NameTextBox);
            Controls.Add(ResultLabel);
            Controls.Add(NameLabel);
            Controls.Add(ExitButton);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ExitButton;
        private Label NameLabel;
        private Label ResultLabel;
        private TextBox NameTextBox;
        private Button SearchButton;
        private RichTextBox richTextBox;
    }
}