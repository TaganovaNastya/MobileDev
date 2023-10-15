// Программа рисует узоры разных цветов
using System;
using System.Drawing;

class Program
{
    static void CreateColoredPattern(int width, int height, ConsoleColor[] colors, char symbol, string figure)
    {
        if (figure == "квадраты")
        {
            Console.Clear();
            int centerX = width / 2;
            int centerY = height / 2;
            int maxSize = Math.Max(width, height);

            for (int i = maxSize; i >= 2; i -= 2)
            {
                int x = centerX - i / 2;
                int y = centerY - i / 2;

                ConsoleColor color = colors[(maxSize - i) % colors.Length];
                Console.ForegroundColor = color;

                for (int row = 0; row < i; row++)
                {
                    for (int col = 0; col < i; col++)
                    {
                        Console.SetCursorPosition(x + col, y + row);
                        Console.Write(symbol);
                    }
                }
            }

        }
        else if (figure == "кресты")
        {
        }
    }

    static void Main()
    {
        Console.WriteLine("Выберете узор: [квадраты/кресты]");
        string figure = Console.ReadLine()?.ToLower();

        Console.WriteLine("Введите ширину узора: ");
        int width = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите высоту узора: ");
        int height = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите цвета через запятую с большой буквы: Blue,Green,Cyan,Red,Magenta,Yellow,White");
        string[] colorStrings = Console.ReadLine().Split(',');
        ConsoleColor[] colors = new ConsoleColor[colorStrings.Length];

        for (int i = 0; i < colorStrings.Length; i++)
        {
            if (Enum.TryParse(colorStrings[i], true, out ConsoleColor color))
            {
                colors[i] = color;
            }
            else
            {
                Console.WriteLine("Неверный цвет: " + colorStrings[i]);
                return;
            }
        }

        char symbol = '\u2588';

       CreateColoredPattern(width, height, colors, symbol, figure);

      //Console.WriteLine("Нажмите любую клавишу для выхода...");
      Console.ReadKey();
    } 
}





