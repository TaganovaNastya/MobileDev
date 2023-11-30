// See https://aka.ms/new-console-template for more information

var cities=new string[] {"Москва", "Суздаль", "Владимир", "Сочи", "Питер" };

var x1 = cities.Where(v => v.StartsWith("С") && v.Length>4).OrderBy(v=> v).ToArray();

Console.WriteLine(string.Join(Environment.NewLine, x1));
Console.WriteLine();

var x2 = cities.OrderBy(v => v).Select(v=> $"{v.ToLower()}- {v.Contains('м')}").ToArray();

Console.WriteLine(string.Join(Environment.NewLine, x2));
