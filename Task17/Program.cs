using System;

Store<Vehicle> vehicleStore = new Store<Vehicle>();
vehicleStore.Add(new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5));
vehicleStore.Add(new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, FuelType.Hybrid, 540));
vehicleStore.Add(new SportsCar("porsche-911", "Porsche", "911", 2023, 8900000, 8000, FuelType.Gasoline, 450, 3.8));

Console.WriteLine($"Vehicle count: {vehicleStore.Count}");

Vehicle? found = vehicleStore.Find("mercedes-e200");
Console.WriteLine($"Found: {found?.Summary() ?? "Not found"}");

var expensiveVehicles = vehicleStore.Filter(v => v.Price > 5000000);
Console.WriteLine("\nVehicles over 5,000,000 TL:");
foreach (Vehicle v in expensiveVehicles)
{
    Console.WriteLine(v.Summary());
}

vehicleStore.Remove("porsche-911");
Console.WriteLine($"\nVehicle count after removal: {vehicleStore.Count}");

// Now use the exact same Store<T> class, but for Leads
Store<Lead> leadStore = new Store<Lead>();
leadStore.Add(new Lead("lead-1", "Ahmet Yilmaz", "0555-111-2233", "bmw-x5", LeadStatus.New));
leadStore.Add(new Lead("lead-2", "Elif Kaya", "0555-444-5566", "mercedes-e200", LeadStatus.Qualified));

Console.WriteLine($"\nLead count: {leadStore.Count}");

var newLeads = leadStore.Filter(l => l.Status == LeadStatus.New);
Console.WriteLine("New leads:");
foreach (Lead l in newLeads)
{
    Console.WriteLine(l.ShortSummary());
}