// Create a list of vehicle brands in the Shaygan Motors inventory
List<string> brands = new List<string> { "BMW", "Mercedes", "Audi", "Porsche", "Volvo", "Range Rover" };

Console.WriteLine("=== VEHICLE BRANDS IN STOCK ===");

// Loop through and print each one with a number
for (int i = 0; i < brands.Count; i++)
{
    Console.WriteLine($"{i + 1}. {brands[i]}");
}

Console.WriteLine($"\nTotal brands: {brands.Count}");

// Add a new brand
brands.Add("Tesla");
Console.WriteLine($"\nAfter adding Tesla, total: {brands.Count}");

// Check if a brand exists
if (brands.Contains("Audi"))
{
    Console.WriteLine("Audi is in stock.");
}