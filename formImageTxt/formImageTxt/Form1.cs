using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.Util;
namespace formImageTxt
{
    public partial class Form1 : Form
    {
        private string filePath = string.Empty;
        private string lang = string.Empty;
        public Form1()
        {
            InitializeComponent();

            richTextBox1.MouseDown += richTextBox1_MouseDown;
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;

                pictureBox1.Image = Image.FromFile(filePath);
            }
            else
            {
                MessageBox.Show("�������� �� �������!", " ���������� ������� ��������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((String.IsNullOrEmpty(filePath)) || String.IsNullOrWhiteSpace(filePath))
                {
                    throw new Exception("�������� �� �������!");
                }
                else if (toolStripComboBox1.SelectedItem == null)
                {
                    throw new Exception("���� �� ������!");
                }
                else
                {


                    Tesseract tesseract = new Tesseract(@"C:\Users\User\Documents\testdata", lang, OcrEngineMode.TesseractLstmCombined);
                    tesseract.SetImage(new Image<Bgr, byte>(filePath));
                    tesseract.Recognize();
                    richTextBox1.Text = tesseract.GetUTF8Text();
                    tesseract.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
                lang = "rus";
            if (toolStripComboBox1.SelectedIndex == 1)
                lang = "eng";
            if (toolStripComboBox1.SelectedIndex == 2)
                lang = "deu";
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textManipulator textManipulatorInstance = new textManipulator(richTextBox1);
                textManipulatorInstance.ChangeFontColor(colorDialog.Color);
            }
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textManipulator textManipulatorInstance = new textManipulator(richTextBox1);
                textManipulatorInstance.ChangeFont(fontDialog.Font);
            }
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBox1.Text))
                {
                    throw new Exception("��� ������ ��� ����������!");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";
                saveFileDialog.Title = "��������� ��������� ����";
                saveFileDialog.FileName = string.Empty; // �� ��������� ��� �����

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.Write(richTextBox1.Text);
                    }
                    MessageBox.Show("����� ������� �������� � ����!", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point location = richTextBox1.PointToClient(Cursor.Position);
            if (!richTextBox1.ClientRectangle.Contains(location))
            {
                e.Cancel = true;
            }
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // ���������� ����������� ���� � ������� ������� ����
                contextMenuStrip1.Show(richTextBox1, e.Location);
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void ����������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
    }
}