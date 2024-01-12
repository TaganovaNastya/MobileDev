using System.Security.Policy;
using static wfaActivZona5.ActiveZonesManager;
using System.Windows.Forms;

namespace wfaActivZona5
{
    public partial class Form1 : Form
    {
        private string filePath = string.Empty;
        private ActiveZonesManager zonesManager = new ActiveZonesManager();
        private Point startPoint;
        private Point endPoint;
        private bool isSelecting;
        private List<Rectangle> drawnRectangles = new List<Rectangle>();
        private Rectangle selectedZoneRectangle;
        public Form1()
        {
            InitializeComponent();
            listBox1.ContextMenuStrip = contextMenuStrip1;
        }

        private void �������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;

                pictureBox1.Image = Image.FromFile(filePath);

                zonesManager.ClearZones();
                RefreshZonesList();
            }
            else
            {
                MessageBox.Show("�������� �� �������!", " ���������� ������� ��������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void RefreshZonesList()
        {
            listBox1.Items.Clear();
            foreach (var zone in zonesManager.GetZones())
            {
                listBox1.Items.Add(zone);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isSelecting = true;
            startPoint = e.Location;
            endPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                endPoint = e.Location;
                pictureBox1.Invalidate();
            }

            // ���������, ��������� �� ������ ������ ��������� ����
            bool cursorInsideZone = false;
            foreach (Rectangle rectangle in drawnRectangles)
            {
                if (rectangle.Contains(e.Location))
                {
                    cursorInsideZone = true;
                    selectedZoneRectangle = rectangle;
                    break;
                }
            }

            // ���� ������ �� ������ ����, ���������� selectedZoneRectangle
            if (!cursorInsideZone)
            {
                selectedZoneRectangle = Rectangle.Empty;
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isSelecting = false;

            if (startPoint != endPoint)
            {
                using (var addZoneForm = new AddZoneForm())
                {
                    Rectangle selectionRectangle = GetSelectionRectangle();
                    addZoneForm.RectangleX = selectionRectangle.X;
                    addZoneForm.RectangleY = selectionRectangle.Y;
                    addZoneForm.RectangleWidth = selectionRectangle.Width;
                    addZoneForm.RectangleHeight = selectionRectangle.Height;

                    if (addZoneForm.ShowDialog() == DialogResult.OK)
                    {
                        string zoneName = addZoneForm.ZoneName;
                        Rectangle newRectangle = new Rectangle(startPoint, new Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
                        zonesManager.AddZone(zoneName, newRectangle);
                        drawnRectangles.Add(newRectangle);
                        RefreshZonesList();
                    }
                }
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                foreach (Rectangle rectangle in drawnRectangles)
                {
                    if (rectangle != selectedZoneRectangle)
                    {
                        e.Graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }
            if (isSelecting)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawRectangle(pen, GetSelectionRectangle());
                }
            }
        }

        private Rectangle GetSelectionRectangle()
        {
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(endPoint.X - startPoint.X);
            int height = Math.Abs(endPoint.Y - startPoint.Y);

            return new Rectangle(x, y, width, height);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ActiveZonesManager.Zone selectedZone = (ActiveZonesManager.Zone)listBox1.SelectedItem;

                // ������������� ��������� ���� ��� ����������� �� ����
                selectedZoneRectangle = selectedZone.Rectangle;

                // ��������� pictureBox ��� ����������� ��������� ����
                pictureBox1.Invalidate();

                // ���������� ����������� ���� ������ ���� ������ �������
                contextMenuStrip1.Enabled = true;
            }
            else
            {
                // ���� ������� �� ������, ��������� ����������� ����
                contextMenuStrip1.Enabled = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // ���� ������ ������� � listBox1
                �������������ToolStripMenuItem.Enabled = true;
                �������������ToolStripMenuItem.Enabled = true;
                �������ToolStripMenuItem.Enabled = true;
            }
            else
            {
                // ���� ������� �� ������ � listBox1
                �������������ToolStripMenuItem.Enabled = false;
                �������������ToolStripMenuItem.Enabled = false;
                �������ToolStripMenuItem.Enabled = false;
            }
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int selectedIndex = listBox1.SelectedIndex;

                using (var addZoneForm = new AddZoneForm())
                {
                    ActiveZonesManager.Zone selectedZone = (ActiveZonesManager.Zone)listBox1.SelectedItem;

                    // �������� ������� ��������� �������������� � AddZoneForm
                    addZoneForm.ZoneName = selectedZone.Name;
                    addZoneForm.RectangleX = selectedZone.Rectangle.X;
                    addZoneForm.RectangleY = selectedZone.Rectangle.Y;
                    addZoneForm.RectangleWidth = selectedZone.Rectangle.Width;
                    addZoneForm.RectangleHeight = selectedZone.Rectangle.Height;

                    if (addZoneForm.ShowDialog() == DialogResult.OK)
                    {
                        // �������� ����� ��������� �������������� �� AddZoneForm
                        string newName = addZoneForm.ZoneName;
                        int newX = addZoneForm.RectangleX;
                        int newY = addZoneForm.RectangleY;
                        int newWidth = addZoneForm.RectangleWidth;
                        int newHeight = addZoneForm.RectangleHeight;

                        // ��������� ��������� � ����
                        zonesManager.EditZone(selectedIndex, newName, newX, newY, newWidth, newHeight);

                        // ��������� drawnRectangles � ������ �����������
                        drawnRectangles[selectedIndex] = new Rectangle(newX, newY, newWidth, newHeight);

                        RefreshZonesList();
                        pictureBox1.Invalidate();
                    }
                }
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int selectedIndex = listBox1.SelectedIndex;

                zonesManager.DeleteZone(selectedIndex);

                // ������� ��������� ������������� �� drawnRectangles
                drawnRectangles.RemoveAt(selectedIndex);

                // ��������� ������ � �������������� �����������
                RefreshZonesList();
                pictureBox1.Invalidate();
            }
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int selectedIndex = listBox1.SelectedIndex;

                using (var addZoneForm = new AddZoneForm())
                {
                    ActiveZonesManager.Zone selectedZone = zonesManager.GetZones()[selectedIndex];
                    addZoneForm.ZoneName = selectedZone.Name;

                    if (addZoneForm.ShowDialog() == DialogResult.OK)
                    {
                        string newName = addZoneForm.ZoneName;

                        zonesManager.ChangeZoneName(selectedIndex, newName);
                        RefreshZonesList();
                    }
                }
            }
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = @"C:\Users\User\source\repos\TaganovaNastya\MobileDev\wfaActivZona5\zone";
                saveFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string imagePath = openFileDialog1.FileName; // �������� ���� � ��������� �����������

                    zonesManager.SaveToFileTxt(filePath, imagePath);
                }
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\User\source\repos\TaganovaNastya\MobileDev\wfaActivZona5\zone";
                openFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // �������� ����� LoadFromFileTxt ���������� zonesManager
                    zonesManager.LoadFromFileTxt(filePath);

                    string imagePath = zonesManager.GetImagePath();

                    // ��������� ����������� � PictureBox
                    pictureBox1.Image = Image.FromFile(imagePath);
                    // ����� �������� �� ����� ����� ����� �������� ���������, ���� ��� ����������
                    RefreshZonesList();
                    RefreshZonesOnImage();
                    
                }
            }
 
        
        }
        private void RefreshZonesOnImage()
        {
            // ������� ���������� ��������������
            drawnRectangles.Clear();

            // �������� ������� ����
            List<ActiveZonesManager.Zone> zones = zonesManager.GetZones();

            
            // �������� ������ Graphics ��� ��������� �� PictureBox
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                // ������������ �������������� ��� ������ ����
                foreach (var zone in zones)
                {
                    Rectangle rectangle = zone.Rectangle;
                  //g.DrawRectangle(Pens.Red, rectangle); 
                    drawnRectangles.Add(rectangle);
                }
            }

            // �������������� PictureBox
            pictureBox1.Invalidate();
        }

    }   
}

