// Store vehicle information in variables
string brand = "BMW";
string model = "X5 xDrive40i M Sport";
int year = 2022;
double price = 5850000.0;
int mileage = 31000;
bool forSale = true;

// Print the info using string interpolation
Console.WriteLine("=== VEHICLE INFO ===");
Console.WriteLine($"Brand: {brand}");
Console.WriteLine($"Model: {model}");
Console.WriteLine($"Year: {year}");
Console.WriteLine($"Price: {price:N0} TL");
Console.WriteLine($"Mileage: {mileage:N0} km");
Console.WriteLine($"For Sale: {(forSale ? "Yes" : "No")}");