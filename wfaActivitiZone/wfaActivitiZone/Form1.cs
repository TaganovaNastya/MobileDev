namespace wfaActivitiZone
{
    public partial class Form1 : Form
    {
        private string filePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void �������ToolStripMenuItem1_Click(object sender, EventArgs e)
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


    }
}