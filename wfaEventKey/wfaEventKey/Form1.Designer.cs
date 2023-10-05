namespace wfaEventKey
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
            laText = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            laText.AutoSize = true;
            laText.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            laText.Location = new Point(101, 64);
            laText.Name = "label1";
            laText.Size = new Size(130, 54);
            laText.TabIndex = 0;
            laText.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 180);
            Controls.Add(laText);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label laText;
    }
}