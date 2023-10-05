// See https://aka.ms/new-console-template for more information
Console.WriteLine("number:");

int value1 = int.Parse(Console.ReadLine());
Console.WriteLine(value1);

int value2;
int.TryParse(Console.ReadLine(), out value2);
Console.WriteLine(value2);

int value3 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(value3);
