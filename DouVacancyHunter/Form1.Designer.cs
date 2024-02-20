namespace DouVacancyHunter
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
            Start = new Button();
            StatusLabel = new Label();
            PathTextBox = new TextBox();
            TechnologyBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ExperienceBox = new ComboBox();
            SuspendLayout();
            // 
            // Start
            // 
            Start.Location = new Point(363, 77);
            Start.Name = "Start";
            Start.Size = new Size(174, 99);
            Start.TabIndex = 0;
            Start.Text = "Пошук";
            Start.UseVisualStyleBackColor = true;
            Start.Click += StartButtonClick;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(246, 235);
            StatusLabel.MaximumSize = new Size(100, 0);
            StatusLabel.MinimumSize = new Size(300, 0);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(300, 20);
            StatusLabel.TabIndex = 1;
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(33, 39);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(212, 27);
            PathTextBox.TabIndex = 2;
            // 
            // TechnologyBox
            // 
            TechnologyBox.Location = new Point(33, 113);
            TechnologyBox.Name = "TechnologyBox";
            TechnologyBox.Size = new Size(212, 27);
            TechnologyBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 16);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 5;
            label1.Text = "Шлях до файлу";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 90);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 6;
            label2.Text = "Технологія";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 165);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 7;
            label3.Text = "Стаж";
            // 
            // ExperienceBox
            // 
            ExperienceBox.FormattingEnabled = true;
            ExperienceBox.Location = new Point(33, 188);
            ExperienceBox.Name = "ExperienceBox";
            ExperienceBox.Size = new Size(212, 28);
            ExperienceBox.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 278);
            Controls.Add(ExperienceBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TechnologyBox);
            Controls.Add(PathTextBox);
            Controls.Add(StatusLabel);
            Controls.Add(Start);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Start;
        private Label StatusLabel;
        private TextBox PathTextBox;
        private TextBox TechnologyBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox ExperienceBox;
    }
}
