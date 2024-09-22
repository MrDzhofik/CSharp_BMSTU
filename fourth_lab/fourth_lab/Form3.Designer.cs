namespace fourth_lab
{
    partial class Form3
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
            EditButton = new Button();
            StatusLabel = new Label();
            StatusTextBox = new TextBox();
            MainLabel = new Label();
            NameTextBox = new TextBox();
            NameLabel = new Label();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Font = new Font("Segoe UI", 14F);
            ExitButton.Location = new Point(677, 386);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(111, 52);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // EditButton
            // 
            EditButton.Font = new Font("Segoe UI", 14F);
            EditButton.Location = new Point(538, 386);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(133, 52);
            EditButton.TabIndex = 1;
            EditButton.Text = "Изменить";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Font = new Font("Segoe UI", 14F);
            StatusLabel.Location = new Point(173, 245);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(162, 32);
            StatusLabel.TabIndex = 2;
            StatusLabel.Text = "Новый статус";
            // 
            // StatusTextBox
            // 
            StatusTextBox.Font = new Font("Segoe UI", 14F);
            StatusTextBox.Location = new Point(341, 245);
            StatusTextBox.Name = "StatusTextBox";
            StatusTextBox.Size = new Size(254, 39);
            StatusTextBox.TabIndex = 3;
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.Font = new Font("Segoe UI", 14F);
            MainLabel.Location = new Point(228, 73);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(309, 32);
            MainLabel.TabIndex = 4;
            MainLabel.Text = "Изменение статуса задачи";
            // 
            // NameTextBox
            // 
            NameTextBox.Font = new Font("Segoe UI", 14F);
            NameTextBox.Location = new Point(341, 149);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(254, 39);
            NameTextBox.TabIndex = 6;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 14F);
            NameLabel.Location = new Point(132, 152);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(203, 32);
            NameLabel.TabIndex = 5;
            NameLabel.Text = "Название задачи";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NameTextBox);
            Controls.Add(NameLabel);
            Controls.Add(MainLabel);
            Controls.Add(StatusTextBox);
            Controls.Add(StatusLabel);
            Controls.Add(EditButton);
            Controls.Add(ExitButton);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ExitButton;
        private Button EditButton;
        private Label StatusLabel;
        private TextBox StatusTextBox;
        private Label MainLabel;
        private TextBox NameTextBox;
        private Label NameLabel;
    }
}