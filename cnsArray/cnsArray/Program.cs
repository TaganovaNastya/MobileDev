// Массив Array

string[] cities = { "Воронеж", "Сочи", "Казань" };
Console.WriteLine(cities[0]);
Console.WriteLine(cities[^1]);
Console.WriteLine("-----------");
//1
for (int i = 0; i < cities.Length; i++)
{
    Console.WriteLine(cities[i]);
}
Console.WriteLine();

foreach (var city in cities)
{
    Console.WriteLine(city);
}

//Изменить размер массива
Array.Resize(ref cities, 3);
Console.WriteLine(String.Join(' ', cities));

//пустой массив
string[] m1 = { };
string[] m2 = Array.Empty<string>();