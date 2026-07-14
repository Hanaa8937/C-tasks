using System;

Console.Write("Enter vehicle price: ");
double price = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Enter vehicle year: ");
int year = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Enter fuel type (Gasoline/Diesel/Hybrid): ");
string fuelType = Console.ReadLine() ?? "";

// Determine price segment
string segment;
if (price <= 3000000)
{
    segment = "Economy";
}
else if (price <= 5000000)
{
    segment = "Mid-Range";
}
else if (price <= 7000000)
{
    segment = "Premium";
}
else
{
    segment = "Luxury";
}

// Determine vehicle condition based on year
string condition;
if (year >= 2024 && year <= 2026)
{
    condition = "Like new";
}
else if (year >= 2021 && year <= 2023)
{
    condition = "Lightly used";
}
else if (year >= 2018 && year <= 2020)
{
    condition = "Moderately used";
}
else
{
    condition = "Older model";
}

// Environmental impact message using switch
string impact = fuelType switch
{
    "Gasoline" => "Moderate emissions",
    "Diesel" => "High torque, drive carefully",
    "Hybrid" => "Low emissions, eco-friendly",
    _ => "Unknown fuel type"
};

Console.WriteLine("\n=== CLASSIFICATION RESULT ===");
Console.WriteLine($"Price Segment: {segment}");
Console.WriteLine($"Condition: {condition}");
Console.WriteLine($"Environmental Impact: {impact}");