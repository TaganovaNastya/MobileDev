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

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Картинка не выбрана!", " Необходимо выбрать картинку", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            // Проверяем, находится ли курсор внутри выбранной зоны
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

            // Если курсор не внутри зоны, сбрасываем selectedZoneRectangle
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

                // Устанавливаем выбранную зону для отображения на фото
                selectedZoneRectangle = selectedZone.Rectangle;

                // Обновляем pictureBox для отображения выбранной зоны
                pictureBox1.Invalidate();

                // Показываем контекстное меню только если выбран элемент
                contextMenuStrip1.Enabled = true;
            }
            else
            {
                // Если элемент не выбран, отключаем контекстное меню
                contextMenuStrip1.Enabled = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Если выбран элемент в listBox1
                редактироватьToolStripMenuItem.Enabled = true;
                переименоватьToolStripMenuItem.Enabled = true;
                удалитьToolStripMenuItem.Enabled = true;
            }
            else
            {
                // Если элемент не выбран в listBox1
                редактироватьToolStripMenuItem.Enabled = false;
                переименоватьToolStripMenuItem.Enabled = false;
                удалитьToolStripMenuItem.Enabled = false;
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int selectedIndex = listBox1.SelectedIndex;

                using (var addZoneForm = new AddZoneForm())
                {
                    ActiveZonesManager.Zone selectedZone = (ActiveZonesManager.Zone)listBox1.SelectedItem;

                    // Передаем текущие параметры прямоугольника в AddZoneForm
                    addZoneForm.ZoneName = selectedZone.Name;
                    addZoneForm.RectangleX = selectedZone.Rectangle.X;
                    addZoneForm.RectangleY = selectedZone.Rectangle.Y;
                    addZoneForm.RectangleWidth = selectedZone.Rectangle.Width;
                    addZoneForm.RectangleHeight = selectedZone.Rectangle.Height;

                    if (addZoneForm.ShowDialog() == DialogResult.OK)
                    {
                        // Получаем новые параметры прямоугольника из AddZoneForm
                        string newName = addZoneForm.ZoneName;
                        int newX = addZoneForm.RectangleX;
                        int newY = addZoneForm.RectangleY;
                        int newWidth = addZoneForm.RectangleWidth;
                        int newHeight = addZoneForm.RectangleHeight;

                        // Применяем изменения к зоне
                        zonesManager.EditZone(selectedIndex, newName, newX, newY, newWidth, newHeight);

                        // Обновляем drawnRectangles с новыми параметрами
                        drawnRectangles[selectedIndex] = new Rectangle(newX, newY, newWidth, newHeight);

                        RefreshZonesList();
                        pictureBox1.Invalidate();
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int selectedIndex = listBox1.SelectedIndex;

                zonesManager.DeleteZone(selectedIndex);

                // Удаляем выбранный прямоугольник из drawnRectangles
                drawnRectangles.RemoveAt(selectedIndex);

                // Обновляем список и перерисовываем изображение
                RefreshZonesList();
                pictureBox1.Invalidate();
            }
        }

        private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = @"C:\Users\User\source\repos\TaganovaNastya\MobileDev\wfaActivZona5\zone";
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string imagePath = openFileDialog1.FileName; // Получаем путь к открытому изображению

                    zonesManager.SaveToFileTxt(filePath, imagePath);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\User\source\repos\TaganovaNastya\MobileDev\wfaActivZona5\zone";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Вызываем метод LoadFromFileTxt экземпляра zonesManager
                    zonesManager.LoadFromFileTxt(filePath);

                    string imagePath = zonesManager.GetImagePath();

                    // Загружаем изображение в PictureBox
                    pictureBox1.Image = Image.FromFile(imagePath);
                    // После загрузки из файла можно также обновить интерфейс, если это необходимо
                    RefreshZonesList();
                    RefreshZonesOnImage();
                    
                }
            }
 
        
        }
        private void RefreshZonesOnImage()
        {
            // Очищаем предыдущие прямоугольники
            drawnRectangles.Clear();

            // Получаем текущие зоны
            List<ActiveZonesManager.Zone> zones = zonesManager.GetZones();

            
            // Получаем объект Graphics для рисования на PictureBox
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                // Отрисовываем прямоугольники для каждой зоны
                foreach (var zone in zones)
                {
                    Rectangle rectangle = zone.Rectangle;
                  //g.DrawRectangle(Pens.Red, rectangle); 
                    drawnRectangles.Add(rectangle);
                }
            }

            // Перерисовываем PictureBox
            pictureBox1.Invalidate();
        }

    }   
}

