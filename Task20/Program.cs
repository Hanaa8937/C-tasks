using System;

IRepository<Vehicle> repository = new JsonRepository<Vehicle>("vehicles_repo.json");
VehicleRepoService service = new VehicleRepoService(repository);

Console.WriteLine("--- Adding vehicles ---");
await service.AddVehicleAsync(new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5));
await service.AddVehicleAsync(new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, FuelType.Hybrid, 540));
Console.WriteLine("Added.");

Console.WriteLine("\n--- Listing all vehicles ---");
foreach (Vehicle v in await service.ListAllAsync())
{
    Console.WriteLine(v.Summary());
}

Console.WriteLine("\n--- Trying to add a duplicate ID ---");
try
{
    await service.AddVehicleAsync(new Sedan("bmw-x5", "Fake", "Duplicate", 2020, 1000000, 0, FuelType.Gasoline, 400));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\n--- Deleting mercedes-e200 ---");
await service.DeleteVehicleAsync("mercedes-e200");

Console.WriteLine("\n--- Listing after delete ---");
foreach (Vehicle v in await service.ListAllAsync())
{
    Console.WriteLine(v.Summary());
}

Console.WriteLine("\n--- Trying to delete a vehicle that doesn't exist ---");
try
{
    await service.DeleteVehicleAsync("tesla-s");
}
catch (VehicleNotFoundException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}