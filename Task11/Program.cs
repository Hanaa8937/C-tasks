using System;
using System.Collections.Generic;
using System.Linq;

List<Vehicle> vehicles = new List<Vehicle>();
vehicles.Add(new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, "Gasoline", true, 5));
vehicles.Add(new Suv("range-sport", "Range Rover", "Sport", 2022, 6900000, 20000, "Diesel", true, 5));
vehicles.Add(new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, "Hybrid", 540));
vehicles.Add(new Sedan("audi-a6", "Audi", "A6", 2022, 4900000, 25000, "Gasoline", 530));
vehicles.Add(new SportsCar("porsche-911", "Porsche", "911", 2023, 8900000, 8000, "Gasoline", 450, 3.8));
vehicles.Add(new SportsCar("audi-r8", "Audi", "R8", 2021, 9500000, 15000, "Gasoline", 570, 3.4));

// 1. Only SUVs
Console.WriteLine("--- SUVs only ---");
var suvsOnly = vehicles.Where(v => v.BodyType == "SUV");
foreach (var v in suvsOnly)
{
    Console.WriteLine(v.Summary());
}

// 2. Under 5,000,000 TL
Console.WriteLine("\n--- Under 5,000,000 TL ---");
var cheapVehicles = vehicles.Where(v => v.Price < 5000000);
foreach (var v in cheapVehicles)
{
    Console.WriteLine(v.Summary());
}

// 3. Sorted by price, cheapest first
Console.WriteLine("\n--- Sorted by price (cheapest first) ---");
var byPriceAsc = vehicles.OrderBy(v => v.Price);
foreach (var v in byPriceAsc)
{
    Console.WriteLine(v.Summary());
}

// 4. Sorted by year, newest first
Console.WriteLine("\n--- Sorted by year (newest first) ---");
var byYearDesc = vehicles.OrderByDescending(v => v.Year);
foreach (var v in byYearDesc)
{
    Console.WriteLine(v.Summary());
}

// 5. Just brand + price (Select creates a new shape)
Console.WriteLine("\n--- Brand and price only ---");
var brandPriceOnly = vehicles.Select(v => new { v.Brand, v.Price });
foreach (var item in brandPriceOnly)
{
    Console.WriteLine($"{item.Brand} - {item.Price:N0} TL");
}

// 6. Find one specific vehicle
Console.WriteLine("\n--- Find bmw-x5 ---");
var found = vehicles.FirstOrDefault(v => v.Id == "bmw-x5");
Console.WriteLine(found?.Summary() ?? "Not found");

// 7. Calculations
Console.WriteLine("\n--- Calculations ---");
Console.WriteLine($"Average price: {vehicles.Average(v => v.Price):N0} TL");
Console.WriteLine($"Total stock value: {vehicles.Sum(v => v.Price):N0} TL");
Console.WriteLine($"Most expensive: {vehicles.Max(v => v.Price):N0} TL");

// 8. Group by fuel type
Console.WriteLine("\n--- Grouped by fuel type ---");
var byFuel = vehicles.GroupBy(v => v.FuelType);
foreach (var group in byFuel)
{
    Console.WriteLine($"{group.Key}: {group.Count()}");
}

// 9. Are all vehicles newer than 2018?
Console.WriteLine("\n--- All newer than 2018? ---");
bool allNew = vehicles.All(v => v.Year > 2018);
Console.WriteLine(allNew);

// 10. Chained query: SUVs, 2021+, sorted by price
Console.WriteLine("\n--- SUVs, 2021 or newer, sorted by price ---");
var chained = vehicles
    .Where(v => v.BodyType == "SUV")
    .Where(v => v.Year >= 2021)
    .OrderBy(v => v.Price);
foreach (var v in chained)
{
    Console.WriteLine(v.Summary());
}