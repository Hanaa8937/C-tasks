using System;

VehicleManager manager = new VehicleManager();

Vehicle v1 = new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5);
manager.AddVehicle(v1);

Console.WriteLine("--- Test 1: Adding a vehicle with an empty ID ---");
try
{
    Vehicle badVehicle = new Suv("", "Tesla", "Model 3", 2023, 3000000, 0, FuelType.Electric, true, 5);
    manager.AddVehicle(badVehicle);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine("Operation completed.\n");
}

Console.WriteLine("--- Test 2: Finding a non-existent vehicle ---");
try
{
    Vehicle found = manager.FindVehicle("tesla-s");
    Console.WriteLine(found);
}
catch (VehicleNotFoundException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine("Operation completed.\n");
}

Console.WriteLine("--- Test 3: Assigning a negative price ---");
try
{
    manager.UpdatePrice("bmw-x5", -500);
}
catch (InvalidPriceException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine("Operation completed.\n");
}

Console.WriteLine("--- Test 4: Invalid status transition ---");
try
{
    manager.UpdateStatus("bmw-x5", VehicleStatus.Archived); // Draft -> Archived is not allowed
}
catch (StatusTransitionException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine("Operation completed.\n");
}

Console.WriteLine("Program finished without crashing.");