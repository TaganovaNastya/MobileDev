namespace wfaActivZona5
{
    partial class AddZoneForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            numericUpDownX = new TextBox();
            numericUpDownY = new TextBox();
            numericUpDownWidth = new TextBox();
            numericUpDownHeight = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(165, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 1;
            label1.Text = "Введите название зоны:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(83, 261);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(191, 261);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Закрыть";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // numericUpDownX
            // 
            numericUpDownX.Location = new Point(165, 84);
            numericUpDownX.Name = "numericUpDownX";
            numericUpDownX.Size = new Size(145, 23);
            numericUpDownX.TabIndex = 4;
            // 
            // numericUpDownY
            // 
            numericUpDownY.Location = new Point(165, 124);
            numericUpDownY.Name = "numericUpDownY";
            numericUpDownY.Size = new Size(145, 23);
            numericUpDownY.TabIndex = 5;
            // 
            // numericUpDownWidth
            // 
            numericUpDownWidth.Location = new Point(165, 167);
            numericUpDownWidth.Name = "numericUpDownWidth";
            numericUpDownWidth.Size = new Size(145, 23);
            numericUpDownWidth.TabIndex = 6;
            // 
            // numericUpDownHeight
            // 
            numericUpDownHeight.Location = new Point(165, 210);
            numericUpDownHeight.Name = "numericUpDownHeight";
            numericUpDownHeight.Size = new Size(145, 23);
            numericUpDownHeight.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 87);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 8;
            label2.Text = "X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 127);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 9;
            label3.Text = "Y:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 167);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 10;
            label4.Text = "Ширина:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(105, 213);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 11;
            label5.Text = "Высота:";
            // 
            // AddZoneForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 305);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDownHeight);
            Controls.Add(numericUpDownWidth);
            Controls.Add(numericUpDownY);
            Controls.Add(numericUpDownX);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "AddZoneForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button btnOK;
        private Button btnCancel;
        private TextBox numericUpDownX;
        private TextBox numericUpDownY;
        private TextBox numericUpDownWidth;
        private TextBox numericUpDownHeight;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}