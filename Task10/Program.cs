using System;
using System.Collections.Generic;

Vehicle v1 = new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, "Gasoline", true, 5);
Vehicle v2 = new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, "Hybrid", 540);
Vehicle v3 = new SportsCar("porsche-911", "Porsche", "911", 2023, 8900000, 8000, "Gasoline", 450, 3.8);

Lead lead1 = new Lead("lead-1", "Ahmet Yilmaz", "0555-111-2233", "bmw-x5", "New");
Lead lead2 = new Lead("lead-2", "Elif Kaya", "0555-444-5566", "porsche-911", "Contacted");

Console.WriteLine("--- Testing IPriceable on v1 ---");
Console.WriteLine($"Price with VAT: {v1.CalculatePrice():N0} TL");
v1.ApplyDiscount(10);
Console.WriteLine($"Price after 10% discount: {v1.Price:N0} TL");

Console.WriteLine("\n--- Testing IPrintable ---");
v1.Print();
Console.WriteLine(v1.ShortSummary());
lead1.Print();
Console.WriteLine(lead1.ShortSummary());

Console.WriteLine("\n--- Searching across Vehicles AND Leads together ---");
List<ISearchable> searchables = new List<ISearchable>();
searchables.Add(v1);
searchables.Add(v2);
searchables.Add(v3);
searchables.Add(lead1);
searchables.Add(lead2);

string searchTerm = "porsche";
Console.WriteLine($"Searching for '{searchTerm}':");
foreach (ISearchable item in searchables)
{
    if (item.Search(searchTerm))
    {
        Console.WriteLine($"Match found: {item}");
    }
}

string searchTerm2 = "ahmet";
Console.WriteLine($"\nSearching for '{searchTerm2}':");
foreach (ISearchable item in searchables)
{
    if (item.Search(searchTerm2))
    {
        Console.WriteLine($"Match found: {item}");
    }
}