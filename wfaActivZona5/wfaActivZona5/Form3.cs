using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaActivZona5
{
    public partial class OpenFile : Form
    {
        string folderPath = @"C:\Users\User\source\repos\TaganovaNastya\MobileDev\wfaActivZona5\zone";
        public OpenFile()
        {
            InitializeComponent();


            PopulateFileList(folderPath);
        }

        private void PopulateFileList(string folderPath)
        {
            // Получаем список файлов в папке
            string[] files = Directory.GetFiles(folderPath, "*.txt");

            // Очищаем ListBox перед добавлением новых элементов
            listBox1.Items.Clear();

            // Заполняем ListBox выбранными файлами
            listBox1.Items.AddRange(files.Select(Path.GetFileName).ToArray());
        }

        public event Action<string> FileSelected;
        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Ваш код для обработки выбранного файла
                string selectedFile = Path.Combine(folderPath, (string)listBox1.SelectedItem);
                FileSelected?.Invoke((string)listBox1.SelectedItem);
                Close();
            }
            else
            {
                MessageBox.Show("Выберите файл для открытия");
            }
        }
    
}   }
