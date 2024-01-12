namespace wfaGraphicSinCos
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;

       
        /// <param name="disposing"
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
            this.pbCharts = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharts)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCharts
            // 
            this.pbCharts.BackColor = System.Drawing.Color.Transparent;
            this.pbCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCharts.Location = new System.Drawing.Point(0, 0);
            this.pbCharts.Name = "pbCharts";
            this.pbCharts.Size = new System.Drawing.Size(823, 465);
            this.pbCharts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCharts.TabIndex = 0;
            this.pbCharts.TabStop = false;
            this.pbCharts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCharts_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 465);
            this.Controls.Add(this.pbCharts);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbCharts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbCharts;
    }
}