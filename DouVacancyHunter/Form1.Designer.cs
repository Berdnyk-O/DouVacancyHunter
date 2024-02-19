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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 278);
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
    }
}
