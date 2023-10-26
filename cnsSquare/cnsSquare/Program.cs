bool isContinue;
bool Draw;
do
{
    Console.WriteLine("Ширина фигуры:");
    int.TryParse(Console.ReadLine(), out int width);
    Console.WriteLine("Высота фигуры:");
    int.TryParse(Console.ReadLine(), out int hight);
    Console.WriteLine("Символ рисования:");
    char.TryParse(Console.ReadLine(), out char simvol);
    Console.WriteLine("Закрасить? [Y/N] ->");

    Draw = Console.ReadLine()?.ToUpper() == "Y";


    Console.WriteLine(new String(simvol, width));

    if (Draw == true)
    {
        for (int i = 1; i< hight - 1; i++) {

            Console.WriteLine(new String(simvol, width));

        }
    }
    else { 

        for (int i = 1; i < hight - 1 ; i++)
        {
            Console.WriteLine(simvol + new String(' ', width - 2) + simvol);
        }
    }
    
    Console.WriteLine(new String(simvol, width));

    Console.Write("Продолжить? [Y/N] ->");

    isContinue = Console.ReadLine()?.ToUpper() == "Y";
} while (isContinue);