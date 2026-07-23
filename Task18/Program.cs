using System;
using Microsoft.Extensions.DependencyInjection;

// --- Test 1: Using MemoryStore directly (no DI yet) ---
Console.WriteLine("--- Test with MemoryStore ---");
IStore<Vehicle> memStore = new MemoryStore<Vehicle>();
VehicleService memService = new VehicleService(memStore);
memService.AddVehicle(new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5));
Console.WriteLine($"Count: {memService.Count}");
memService.ListAll();

// --- Test 2: Using FileStore directly (no DI yet) ---
Console.WriteLine("\n--- Test with FileStore ---");
IStore<Vehicle> fileStore = new FileStore<Vehicle>("vehicles_di.json");
VehicleService fileService = new VehicleService(fileStore);
fileService.AddVehicle(new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, FuelType.Hybrid, 540));
Console.WriteLine($"Count: {fileService.Count}");
fileService.ListAll();

// --- Test 3: Using an actual DI container ---
Console.WriteLine("\n--- Test with DI container ---");
var services = new ServiceCollection();
services.AddSingleton<IStore<Vehicle>>(new MemoryStore<Vehicle>());
services.AddSingleton<VehicleService>();

ServiceProvider provider = services.BuildServiceProvider();
VehicleService diService = provider.GetRequiredService<VehicleService>();

diService.AddVehicle(new SportsCar("porsche-911", "Porsche", "911", 2023, 8900000, 8000, FuelType.Gasoline, 450, 3.8));
Console.WriteLine($"Count: {diService.Count}");
diService.ListAll();