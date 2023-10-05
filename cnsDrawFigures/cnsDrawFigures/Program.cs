using System.Runtime.InteropServices;

bool isContinue;
bool draw;
int snakeLength;
char snakeSegment = '\u25A0'; 
string? figure;
int height;
int number;
string orientation;
string direction;
int length;
int width;
//Console.WriteLine(new String(snakeSegment, snakeLength));

do
{
    Console.WriteLine("Выберете фигуру: [ромб/песочные часы/змейка/крест]");
    figure = Console.ReadLine()?.ToLower();
    if (figure == "ромб")
    {
        Console.WriteLine("Введите высоту ромба:");
        while (!int.TryParse(Console.ReadLine(), out height) || height % 2 == 0)
        {
            Console.WriteLine("Высота должна быть нечетным положительным числом. Попробуйте снова:");
        }

        Console.WriteLine("Введите символ для рисования ромба:");
        char symbol = Console.ReadLine()[0];

        Console.WriteLine("Закрасить? [Y/N] ->");
        draw = Console.ReadLine()?.ToUpper() == "Y";
        if (draw == true) { 
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (j >= Math.Abs(height / 2 - i) && j <= height - Math.Abs(height / 2 - i) - 1)
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
        else
        {
            for (int i = -2; i < height + 2; i++)
            {
                for (int j = -2; j < height + 2; j++)
                {
                    if (j >= Math.Abs(height/ 2 - i) && j <= height - Math.Abs(height / 2 - i) - 1)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(symbol);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }

    }


    if (figure == "песочные часы")
    {
        Console.WriteLine("Введите высоту песочных часов:");
        while (!int.TryParse(Console.ReadLine(), out height) || height % 2 == 0)
        {
            Console.WriteLine("Высота должна быть нечетным положительным числом. Попробуйте снова:");
        }

        Console.WriteLine("Хотите сделать часы из цифр? [Y/N] ->\"");
        draw = Console.ReadLine()?.ToUpper() == "Y";
        if (draw == false)
        {

            Console.WriteLine("Введите символ для рисования фигуры:");
            char symbol = Console.ReadLine()[0];


            for (int y = 0; y < height; y++)
            {
                Console.Write("   ");
                for (int x = 0; x < height; x++)
                {
                    if ((y <= x && y <= height - x - 1) || (y >= height - x - 1 && y >= x))
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {   number = (height + 1) / 2;
            for (int y = 0; y < height; y++)
            {
                number = number - 1;
                Console.Write("   ");
                for (int x = 0; x < height; x++)
                {
                    if ((y <= x && y <= height - x - 1) || (y >= height - x - 1 && y >= x))
                    {
                        Console.Write(Math.Abs(number));
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        
    }

    if (figure == "змейка")
    {
        length = 6;
        Console.WriteLine("Выберите ориентацию (горизонтальная/вертикальная):");
        orientation = Console.ReadLine()?.ToLower();
        Console.WriteLine("Выберите направление (по часовой/против часовой):");
        direction = Console.ReadLine()?.ToLower();

        for (int i = 0; i <= length; i++)
        {
            if (orientation == "вертикальная" & direction == "против часовой") { 
            if (i % 2 == 0)
            {
                Console.WriteLine(new String(snakeSegment, 5));
            }
            else if (i % 3 == 0 & i % 3 != 2)
            {
                Console.WriteLine(new String(' ', 4) + snakeSegment);
            }
            else
            {
                Console.WriteLine(snakeSegment + new String(' ', 4));
            }
            }
            else if(orientation == "вертикальная" & direction == "по часовой")
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(new String(snakeSegment, 5));
                }
                else if (i % 3 == 0 & i % 3 != 2)
                {
                    Console.WriteLine(snakeSegment + new String(' ', 4));
                }
                else
                {
                    Console.WriteLine(new String(' ', 4) + snakeSegment);
                }
            }
            else if (orientation == "горизонтальная" & direction == "по часовой"){
                if (i != 0 & i != length)
                {

                    for (int j = 0; j < length; j++)
                    {
                        Console.Write(snakeSegment + new String(' ', 5));
                    }
                    Console.WriteLine();

                }
                else if(i == 0)
                {
                    Console.WriteLine(new String(snakeSegment, 7) + new String(' ', 5) + new String(snakeSegment, 7) + new String(' ', 5) + new String(snakeSegment, 7));
                }else
                {
                    Console.WriteLine(new String(' ', 6) + new String(snakeSegment, 7) + new String(' ', 5) + new String(snakeSegment, 7));
                }
            }
            else
            {

            }

        }
        

    }

    if (figure == "крест")
    {
        //int length;
        //int width;
        Console.WriteLine("Введите длину креста:");
        while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.WriteLine("Длина должна быть положительным числом. Попробуйте снова:");
        }

        Console.WriteLine("Введите ширину креста:");
        while (!int.TryParse(Console.ReadLine(), out width) || width <= 0)
        {
            Console.WriteLine("Ширина должна быть положительным числом. Попробуйте снова:");
        }

        Console.WriteLine("Введите символ для первой диагональной линии креста:");
        char symbol1 = Console.ReadLine()[0];

        Console.WriteLine("Введите символ для второй диагональной линии креста:");
        char symbol2 = Console.ReadLine()[0];

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (i == j)
                {
                    Console.Write(symbol1);
                }
                else if (i == length - j - 1)
                {
                    Console.Write(symbol2);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
    Console.ReadLine();
        Console.Write("Продолжить? [Y/N] ->");

    isContinue = Console.ReadLine()?.ToUpper() == "Y";

} while (isContinue);



