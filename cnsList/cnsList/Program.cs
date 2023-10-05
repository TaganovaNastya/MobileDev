//Список(List)

//Обычный список

using System.Collections;

ArrayList arrayList = new ArrayList();
arrayList.Add(100);
arrayList.Add("Hello");
arrayList.Add(3.14);

//Обобщённый список

List<string> cities = new() { "Москва", "Воронеж" };
cities.Add("Минск");
cities.AddRange(new string[] { "Севастополь", "Ялта" });
cities.RemoveAt(1);
Console.WriteLine(String.Join(" ", cities));
cities.Sort();
Console.WriteLine(String.Join(" ", cities));