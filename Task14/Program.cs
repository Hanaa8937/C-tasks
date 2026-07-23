using System;
using System.Collections.Generic;
using System.Text.Json;

DataManager manager = new DataManager();

List<Vehicle> vehicles = new List<Vehicle>
{
    new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5),
    new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, FuelType.Hybrid, 540),
    new SportsCar("porsche-911", "Porsche", "911", 2023, 8900000, 8000, FuelType.Gasoline, 450, 3.8)
};

Console.WriteLine("--- Saving to vehicles.json ---");
manager.Save(vehicles, "vehicles.json");
Console.WriteLine("Saved.");

Console.WriteLine("\n--- Loading back from vehicles.json ---");
List<Vehicle> loaded = manager.Load("vehicles.json");
foreach (Vehicle v in loaded)
{
    Console.WriteLine(v);
}

Console.WriteLine("\n--- Reading db.json directly ---");
string dbText = File.ReadAllText("db.json");
using JsonDocument doc = JsonDocument.Parse(dbText);
JsonElement vehiclesArray = doc.RootElement.GetProperty("vehicles");

foreach (JsonElement item in vehiclesArray.EnumerateArray())
{
    string brand = item.GetProperty("Brand").GetString() ?? "";
    string model = item.GetProperty("Model").GetString() ?? "";
    Console.WriteLine($"{brand} {model}");
}

Console.WriteLine("\n--- Loading from a file that doesn't exist ---");
List<Vehicle> missing = manager.Load("nonexistent.json");
Console.WriteLine($"Loaded {missing.Count} vehicles (should be 0, no crash).");