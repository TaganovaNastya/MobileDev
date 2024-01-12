namespace wfaExam
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
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            lblAttempts = new Label();
            lblTimeRemaining = new Label();
            cmbGridSize = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlFigures = new Panel();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(237, 299);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Начать";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // lblAttempts
            // 
            lblAttempts.AutoSize = true;
            lblAttempts.Location = new Point(12, 21);
            lblAttempts.Name = "lblAttempts";
            lblAttempts.Size = new Size(38, 15);
            lblAttempts.TabIndex = 3;
            lblAttempts.Text = "label2";
            // 
            // lblTimeRemaining
            // 
            lblTimeRemaining.AutoSize = true;
            lblTimeRemaining.Location = new Point(12, 56);
            lblTimeRemaining.Name = "lblTimeRemaining";
            lblTimeRemaining.Size = new Size(38, 15);
            lblTimeRemaining.TabIndex = 4;
            lblTimeRemaining.Text = "label3";
            // 
            // cmbGridSize
            // 
            cmbGridSize.FormattingEnabled = true;
            cmbGridSize.Location = new Point(5, 93);
            cmbGridSize.Name = "cmbGridSize";
            cmbGridSize.Size = new Size(121, 23);
            cmbGridSize.TabIndex = 5;
            // 
            // pnlFigures
            // 
            pnlFigures.Location = new Point(177, 12);
            pnlFigures.Name = "pnlFigures";
            pnlFigures.Size = new Size(354, 261);
            pnlFigures.TabIndex = 6;
            pnlFigures.Click += pnlFigures_Click;
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 334);
            Controls.Add(pnlFigures);
            Controls.Add(cmbGridSize);
            Controls.Add(lblTimeRemaining);
            Controls.Add(lblAttempts);
            Controls.Add(btnStart);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblAttempts;
        private Label lblTimeRemaining;
        private ComboBox cmbGridSize;
        private System.Windows.Forms.Timer timer1;
        private Panel pnlFigures;
    }
}