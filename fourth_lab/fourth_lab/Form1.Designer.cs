namespace fourth_lab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddButton = new Button();
            ChangeButton = new Button();
            AnalyticButton = new Button();
            AllButton = new Button();
            ExitButton = new Button();
            TextLabel = new Label();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(97, 261);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(110, 76);
            AddButton.TabIndex = 0;
            AddButton.Text = "Добавить задачу";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // ChangeButton
            // 
            ChangeButton.Location = new Point(213, 262);
            ChangeButton.Name = "ChangeButton";
            ChangeButton.Size = new Size(109, 75);
            ChangeButton.TabIndex = 1;
            ChangeButton.Text = "Обновить статус задачи";
            ChangeButton.UseVisualStyleBackColor = true;
            ChangeButton.Click += EditButton_Click;
            // 
            // AnalyticButton
            // 
            AnalyticButton.Location = new Point(328, 262);
            AnalyticButton.Name = "AnalyticButton";
            AnalyticButton.Size = new Size(110, 75);
            AnalyticButton.TabIndex = 2;
            AnalyticButton.Text = "Показать задачи аналитика";
            AnalyticButton.UseVisualStyleBackColor = true;
            AnalyticButton.Click += AnalyticButton_Click;
            // 
            // AllButton
            // 
            AllButton.Location = new Point(444, 262);
            AllButton.Name = "AllButton";
            AllButton.Size = new Size(106, 75);
            AllButton.TabIndex = 3;
            AllButton.Text = "Показать все задачи";
            AllButton.UseVisualStyleBackColor = true;
            AllButton.Click += AllButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = SystemColors.Desktop;
            ExitButton.ForeColor = SystemColors.ButtonFace;
            ExitButton.Location = new Point(604, 344);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(78, 37);
            ExitButton.TabIndex = 4;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // TextLabel
            // 
            TextLabel.AutoSize = true;
            TextLabel.Font = new Font("Segoe UI", 14F);
            TextLabel.Location = new Point(156, 143);
            TextLabel.Name = "TextLabel";
            TextLabel.Size = new Size(394, 32);
            TextLabel.TabIndex = 5;
            TextLabel.Text = "Привет! Выбирай, что тебе нужно";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 393);
            Controls.Add(TextLabel);
            Controls.Add(ExitButton);
            Controls.Add(AllButton);
            Controls.Add(AnalyticButton);
            Controls.Add(ChangeButton);
            Controls.Add(AddButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Button ChangeButton;
        private Button AnalyticButton;
        private Button AllButton;
        private Button ExitButton;
        private Label TextLabel;
    }
}
