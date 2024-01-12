using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;


namespace wfaActivZona5
{
    public class ActiveZonesManager
    {
        private List<Zone> zones = new List<Zone>();
        private string imagePath;

        public void AddZone(string name, Rectangle rectangle)
        {
            Zone newZone = new Zone(name, rectangle);
            zones.Add(newZone);
        }

        public List<Zone> GetZones()
        {
            return zones;
        }

        public void ClearZones()
        {
            zones.Clear();
        }
        
        public class Zone
        {
            public string Name { get; set; }
            public Rectangle Rectangle { get; set; }

            

            public Zone(string name, Rectangle rectangle)
            {
                Name = name;
                Rectangle = rectangle;

                
            }

            public override string ToString()
            {
                return Name;
            }


        }

        public void DeleteZone(int index)
        {
            if (index >= 0 && index < zones.Count)
            {
                zones.RemoveAt(index);
            }
        }

        public void ChangeZoneName(int index, string newName)
        {
            if (index >= 0 && index < zones.Count)
            {
                Zone zoneToEdit = zones[index];
                zoneToEdit.Name = newName;
            }
        }

        public void EditZone(int index, string name, int x, int y, int width, int height)
        {
            if (index >= 0 && index < zones.Count)
            {
                Zone editedZone = zones[index];
                editedZone.Name = name;
                editedZone.Rectangle = new Rectangle(x, y, width, height);
            }
        }

        public void SaveToFileTxt(string filePath, string imagePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Записываем путь к изображению
                    writer.WriteLine($"ImagePath;{imagePath}");

                    // Записываем параметры зон
                    foreach (var zone in zones)
                    {
                        string zoneLine = $"{zone.Name};{zone.Rectangle.X};{zone.Rectangle.Y};{zone.Rectangle.Width};{zone.Rectangle.Height}";
                        writer.WriteLine(zoneLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void LoadFromFileTxt(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Читаем первую строку, содержащую путь к изображению
                    string imagePathLine = reader.ReadLine();

                    if (imagePathLine != null)
                    {
                        // Разделяем строку и получаем путь к изображению
                        string[] imagePathParts = imagePathLine.Split(';');
                        imagePath = imagePathParts[1];

                        // Загружаем изображение
                        

                        // Очищаем текущие зоны
                        ClearZones();

                        // Читаем строки с координатами и размерами зон
                        string zoneLine;
                        while ((zoneLine = reader.ReadLine()) != null)
                        {
                            // Разделяем строку и получаем данные о зоне
                            string[] zoneParts = zoneLine.Split(';');

                            if (zoneParts.Length == 5)
                            {
                                string name = zoneParts[0];
                                int x = int.Parse(zoneParts[1]);
                                int y = int.Parse(zoneParts[2]);
                                int width = int.Parse(zoneParts[3]);
                                int height = int.Parse(zoneParts[4]);

                                // Создаем новую зону и добавляем ее в менеджер зон
                                AddZone(name, new Rectangle(x, y, width, height));
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка в формате строки зоны: {zoneLine}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при открытии файла: {ex.Message}");
            }
        }

        public string GetImagePath()
        {
            return imagePath;
        }


    }
}
