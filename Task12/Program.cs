using System;

Vehicle v1 = new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5);
Console.WriteLine(v1);

// String to enum
Console.WriteLine("\n--- String to enum ---");
BodyType parsedType = Enum.Parse<BodyType>("SUV");
Console.WriteLine($"Parsed: {parsedType}");

// Enum to string
Console.WriteLine("\n--- Enum to string ---");
string typeAsText = parsedType.ToString();
Console.WriteLine($"As text: {typeAsText}");

// Invalid string handled safely
Console.WriteLine("\n--- Invalid string handling ---");
bool success = Enum.TryParse<BodyType>("Truck", out BodyType result);
if (success)
{
    Console.WriteLine($"Parsed: {result}");
}
else
{
    Console.WriteLine("Invalid body type entered.");
}

// Lead status transitions
Console.WriteLine("\n--- Lead status transitions ---");
Lead lead1 = new Lead("lead-1", "Ahmet Yilmaz", "0555-111-2233", "bmw-x5", LeadStatus.New);

Console.WriteLine($"New -> Qualified allowed? {lead1.CanTransitionTo(LeadStatus.Qualified)}");
Console.WriteLine($"New -> Nurturing allowed? {lead1.CanTransitionTo(LeadStatus.Nurturing)}");

lead1.Status = LeadStatus.Closed;
Console.WriteLine($"Closed -> New allowed? {lead1.CanTransitionTo(LeadStatus.New)}");