using System;

// Test the full constructor
Vehicle v1 = new Vehicle("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, "SUV", "Gasoline");
Console.WriteLine(v1);

// Test the simple constructor
Vehicle v2 = new Vehicle("Tesla", "Model 3");
Console.WriteLine(v2);

Console.WriteLine("\n--- Testing price validation ---");
v1.Price = -1000;              // should become 0, and print an update message
Console.WriteLine($"v1 price is now: {v1.Price}");

v1.Price = 6000000;            // valid change
Console.WriteLine($"v1 price is now: {v1.Price:N0}");

Console.WriteLine("\n--- Testing mileage validation ---");
Console.WriteLine($"v1 mileage: {v1.Mileage}");
v1.Mileage = 20000;             // lower than current — should be ignored
Console.WriteLine($"v1 mileage after trying to lower it: {v1.Mileage}");

v1.Mileage = 40000;              // higher — should work
Console.WriteLine($"v1 mileage after increasing it: {v1.Mileage}");

// This next line would NOT compile if uncommented, because Id is readonly:
// v1.Id = "new-id";