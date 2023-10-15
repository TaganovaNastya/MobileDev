namespace cnsGenDice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result1 = RollDice(7); 
            var result2 = RollDice(2, 10); 
            var customFaces = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var result3 = RollDice(4, 8, customFaces);

            Console.WriteLine("Результаты бросков:");
            Console.WriteLine("Бросок 3-х шестигранных кубиков: " + string.Join(", ", result1.results) + " (Сумма: " + result1.total + ")");
            Console.WriteLine("Бросок 2-х десятигранных кубиков: " + string.Join(", ", result2.results) + " (Сумма: " + result2.total + ")");
            Console.WriteLine("Бросок 4-х восьмигранных кубиков: " + string.Join(", ", result3.results) + " (Сумма: " + result3.total + ")");
        }

        public static (int[] results, int total) RollDice(int numberOfDice, int numberOfFaces = 6, int[] faceValues = null)
        {
            if (numberOfDice <= 0)
            {
                Console.WriteLine("Ошибка: Количество кубиков должно быть больше нуля.");
                return (null, 0);
            }
            if (numberOfFaces <= 1)
            {
                Console.WriteLine("Ошибка: Количество граней кубика должно быть больше одной.");
                return (null, 0);
            }
            if (faceValues != null && faceValues.Length != numberOfFaces)
            {
                Console.WriteLine("Ошибка: Количество значений граней должно соответствовать количеству граней кубика.");
                return (null, 0);
            };

            Random random = new Random();
            int[] results = new int[numberOfDice];
            int total = 0;

            if (faceValues == null)
            {
                for (int i = 0; i < numberOfDice; i++)
                {
                    results[i] = random.Next(1, numberOfFaces + 1);
                    total += results[i];
                }
            }
            else
            {
                for (int i = 0; i < numberOfDice; i++)
                {
                    int randomFace = random.Next(numberOfFaces);
                    results[i] = faceValues[randomFace];
                    total += results[i];
                }
            }

            return (results, total);
        }

    }
}