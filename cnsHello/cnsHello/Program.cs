// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ваше имя?");
string? name = Console.ReadLine();
Console.WriteLine("Ваш город?");
string? city = Console.ReadLine();

Console.WriteLine("Имя = " + name + ", Город = " + city);
Console.WriteLine("Имя = {0}, Город = {1}",  name, city);
Console.WriteLine($"Имя = {name}, Город = {city}");
