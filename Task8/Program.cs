using System;
using System.Collections.Generic;

// --- Part 1: Dictionary of vehicles, keyed by ID ---
Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

vehicles.Add("bmw-x5", new Vehicle("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, "SUV", "Gasoline"));
vehicles.Add("mercedes-e200", new Vehicle("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, "Sedan", "Hybrid"));
vehicles.Add("audi-q8", new Vehicle("audi-q8", "Audi", "Q8", 2023, 6250000, 12000, "SUV", "Gasoline"));
vehicles.Add("porsche-macan", new Vehicle("porsche-macan", "Porsche", "Macan", 2020, 5300000, 55000, "SUV", "Gasoline"));
vehicles.Add("volvo-xc90", new Vehicle("volvo-xc90", "Volvo", "XC90", 2021, 4760000, 38000, "SUV", "Diesel"));
vehicles.Add("range-sport", new Vehicle("range-sport", "Range Rover", "Sport", 2022, 6900000, 20000, "SUV", "Diesel"));

// --- Part 2: Look up by ID ---
Console.WriteLine("--- Looking up bmw-x5 ---");
if (vehicles.ContainsKey("bmw-x5"))
{
    Console.WriteLine(vehicles["bmw-x5"]);
}

Console.WriteLine("\n--- Looking up tesla-s (doesn't exist) ---");
if (vehicles.ContainsKey("tesla-s"))
{
    Console.WriteLine(vehicles["tesla-s"]);
}
else
{
    Console.WriteLine("Vehicle not found");
}

// --- Part 3: Count and list all IDs ---
Console.WriteLine($"\nTotal vehicles: {vehicles.Count}");

Console.WriteLine("\nAll vehicle IDs:");
foreach (string id in vehicles.Keys)
{
    Console.WriteLine($"- {id}");
}

// --- Part 4: Delete and re-search ---
Console.WriteLine("\n--- Removing audi-q8 ---");
vehicles.Remove("audi-q8");

if (vehicles.ContainsKey("audi-q8"))
{
    Console.WriteLine(vehicles["audi-q8"]);
}
else
{
    Console.WriteLine("Vehicle not found");
}

// --- Part 5: Group vehicles by brand ---
// Dictionary vs List: a Dictionary looks things up instantly by key (like a phone book by name),
// while a List has to be scanned item by item to find something. Here, brand is the key
// so we can jump straight to "all BMWs" instead of checking every vehicle one by one.
Dictionary<string, List<Vehicle>> byBrand = new Dictionary<string, List<Vehicle>>();

foreach (Vehicle v in vehicles.Values)
{
    if (!byBrand.ContainsKey(v.Brand))
    {
        byBrand[v.Brand] = new List<Vehicle>();
    }
    byBrand[v.Brand].Add(v);
}

Console.WriteLine("\nVehicles per brand:");
foreach (string brand in byBrand.Keys)
{
    Console.WriteLine($"{brand}: {byBrand[brand].Count}");
}

// --- Part 6: Ask user for an ID, use TryGetValue ---
Console.Write("\nEnter a vehicle ID to look up: ");
string searchId = Console.ReadLine() ?? "";

if (vehicles.TryGetValue(searchId, out Vehicle? foundVehicle))
{
    Console.WriteLine(foundVehicle);
}
else
{
    Console.WriteLine("Vehicle not found");
}