// Ask the user which brand they're looking for
Console.Write("Enter a brand to search for: ");
string searchBrand = Console.ReadLine();

List<string> brands = new List<string> { "BMW", "Mercedes", "Audi", "Porsche", "Volvo", "Range Rover" };

// Check if it exists (case-insensitive)
bool found = brands.Contains(searchBrand, StringComparer.OrdinalIgnoreCase);

if (found)
{
    Console.WriteLine($"{searchBrand} is available at Shaygan Motors!");
}
else
{
    Console.WriteLine($"Sorry, we don't have {searchBrand} in stock.");
}

// Ask for a budget and give a message based on it
Console.Write("Enter your budget (TL): ");
double budget = double.Parse(Console.ReadLine());

if (budget >= 5000000)
{
    Console.WriteLine("You can afford our premium SUVs.");
}
else if (budget >= 2000000)
{
    Console.WriteLine("You can afford our sedans.");
}
else
{
    Console.WriteLine("Budget too low for current stock, check back later.");
}