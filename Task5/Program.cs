using System;
using System.Collections.Generic;
using System.Linq;

// --- Part 1: Brands ---
List<string> brands = new List<string> { "BMW", "Mercedes", "Audi", "Porsche", "Volvo", "Range Rover" };

Console.WriteLine($"Number of brands: {brands.Count}");
Console.WriteLine($"Contains Porsche? {brands.Contains("Porsche")}");

brands.Remove("Audi");
Console.WriteLine("\nBrands after removing Audi:");
foreach (string brand in brands)
{
    Console.WriteLine($"- {brand}");
}

// --- Part 2: Prices ---
List<double> prices = new List<double> { 5850000, 4420000, 6250000, 5300000, 4760000, 6900000 };
prices.Sort();

Console.WriteLine("\nPrices sorted (low to high):");
foreach (double price in prices)
{
    Console.WriteLine($"{price:N0} TL");
}

Console.WriteLine("\nPrices above 5,000,000 TL:");
foreach (double price in prices)
{
    if (price > 5000000)
    {
        Console.WriteLine($"{price:N0} TL");
    }
}

Console.WriteLine($"\nMost expensive: {prices.Max():N0} TL");
Console.WriteLine($"Cheapest: {prices.Min():N0} TL");

// --- Part 3: Interactive menu ---
bool running = true;
while (running)
{
    Console.WriteLine("\n=== BRAND MENU ===");
    Console.WriteLine("1. Add brand");
    Console.WriteLine("2. Remove brand");
    Console.WriteLine("3. Search brand");
    Console.WriteLine("4. List all brands");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            Console.Write("Enter new brand: ");
            string newBrand = Console.ReadLine() ?? "";
            brands.Add(newBrand);
            Console.WriteLine($"{newBrand} added.");
            break;

        case "2":
            Console.Write("Enter brand to remove: ");
            string removeBrand = Console.ReadLine() ?? "";
            if (brands.Remove(removeBrand))
            {
                Console.WriteLine($"{removeBrand} removed.");
            }
            else
            {
                Console.WriteLine($"{removeBrand} not found.");
            }
            break;

        case "3":
            Console.Write("Enter brand to search: ");
            string searchBrand = Console.ReadLine() ?? "";
            Console.WriteLine(brands.Contains(searchBrand) ? "Found." : "Not found.");
            break;

        case "4":
            Console.WriteLine("Current brands:");
            foreach (string b in brands)
            {
                Console.WriteLine($"- {b}");
            }
            break;

        case "5":
            running = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}