//Словарь
//Ключ - Значение

//Dictionary<int, string> x = new();
//x.Add(10, "Liski");
//x.Add(20, "Sochi");
//x.Add(40, "Moscow");
//x.Add(60, "Penza");

Dictionary<int, string> x = new()
{
    { 10, "Liski" },
    { 20, "Sochi" },
    { 40, "Moscow" },
    { 60, "Penza" }
};

Console.WriteLine(x[60]);

x[40] = "Kursk";
x[5] = "Voronesh";

foreach (var item in x)
{
    Console.WriteLine($"key={item.Key}, value={item.Value}");
}
