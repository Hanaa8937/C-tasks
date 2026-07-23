using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

// --- DI setup ---
var services = new ServiceCollection();
services.AddSingleton<IRepository<Vehicle>>(new JsonRepository<Vehicle>("data_vehicles.json"));
services.AddSingleton<IRepository<Lead>>(new JsonRepository<Lead>("data_leads.json"));
services.AddSingleton<VehicleRepoService>();
services.AddSingleton<LeadRepoService>();

ServiceProvider provider = services.BuildServiceProvider();
VehicleRepoService vehicleService = provider.GetRequiredService<VehicleRepoService>();
LeadRepoService leadService = provider.GetRequiredService<LeadRepoService>();

Settings settings = new Settings();

Console.WriteLine("=== SHAYGAN MOTORS MANAGEMENT SYSTEM ===");
Console.Write("Select language (en/tr/fa/ar/ru/de): ");
string lang = Console.ReadLine() ?? "en";
if (!settings.SupportedLanguages.Contains(lang)) lang = settings.DefaultLanguage;

// Seed some starting data if empty
var existing = await vehicleService.ListAllAsync();
if (existing.Count == 0)
{
    await vehicleService.AddVehicleAsync(new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5));
    await vehicleService.AddVehicleAsync(new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, FuelType.Hybrid, 540));
    await vehicleService.AddVehicleAsync(new SportsCar("porsche-911", "Porsche", "911", 2023, 8900000, 8000, FuelType.Gasoline, 450, 3.8));
}

bool running = true;
while (running)
{
    Console.WriteLine("\n1. Vehicle Management");
    Console.WriteLine("2. Lead Management");
    Console.WriteLine("4. Reports");
    Console.WriteLine("5. Settings (change language)");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");
    string choice = Console.ReadLine() ?? "";

    try
    {
        switch (choice)
        {
            case "1":
                await VehicleMenu(vehicleService);
                break;

            case "2":
                await LeadMenu(leadService, vehicleService);
                break;

            case "4":
                await ReportsMenu(vehicleService, leadService);
                break;

            case "5":
                Console.Write("New language: ");
                string newLang = Console.ReadLine() ?? lang;
                if (settings.SupportedLanguages.Contains(newLang))
                {
                    lang = newLang;
                    Console.WriteLine($"Language changed to {lang}.");
                }
                else
                {
                    Console.WriteLine("Unsupported language.");
                }
                break;

            case "0":
                running = false;
                Console.WriteLine("Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// --- Sub-menus as local functions ---

async Task VehicleMenu(VehicleRepoService service)
{
    Console.WriteLine("\n1.1 List all  1.2 Search  1.3 Filter  1.4 Add  1.6 Delete");
    Console.Write("Choose: ");
    string sub = Console.ReadLine() ?? "";

    switch (sub)
    {
        case "1.1":
            foreach (Vehicle v in await service.ListAllAsync())
                Console.WriteLine(v.Summary());
            break;

        case "1.2":
            Console.Write("Search term: ");
            string term = Console.ReadLine() ?? "";
            foreach (Vehicle v in await service.SearchAsync(term))
                Console.WriteLine(v.Summary());
            break;

        case "1.3":
            Console.Write("Max price (or blank for no limit): ");
            string maxInput = Console.ReadLine() ?? "";
            double? maxPrice = double.TryParse(maxInput, out double mp) ? mp : null;
            foreach (Vehicle v in await service.FilterAsync(null, null, null, maxPrice))
                Console.WriteLine(v.Summary());
            break;

        case "1.4":
            Console.Write("Brand: ");
            string brand = Console.ReadLine() ?? "";
            Console.Write("Model: ");
            string model = Console.ReadLine() ?? "";
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine() ?? "0");
            string id = $"{brand.ToLower()}-{model.ToLower()}".Replace(" ", "-");
            await service.AddVehicleAsync(new Sedan(id, brand, model, 2024, price, 0, FuelType.Gasoline, 450));
            Console.WriteLine("Added.");
            break;

        case "1.6":
            Console.Write("Vehicle ID to delete: ");
            string delId = Console.ReadLine() ?? "";
            await service.DeleteVehicleAsync(delId);
            Console.WriteLine("Deleted.");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

async Task LeadMenu(LeadRepoService service, VehicleRepoService vService)
{
    Console.WriteLine("\n2.1 List all  2.2 Create  2.3 Update status");
    Console.Write("Choose: ");
    string sub = Console.ReadLine() ?? "";

    switch (sub)
    {
        case "2.1":
            foreach (Lead l in await service.ListAllAsync())
                Console.WriteLine(l.ShortSummary());
            break;

        case "2.2":
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? "";
            Console.Write("Vehicle ID: ");
            string vehicleId = Console.ReadLine() ?? "";
            Lead lead = await service.CreateLeadAsync(name, phone, vehicleId, LeadStatus.New);
            Console.WriteLine($"Created lead {lead.Id}.");
            break;

        case "2.3":
            Console.Write("Lead ID: ");
            string leadId = Console.ReadLine() ?? "";
            Console.Write("New status (New/Qualified/Nurturing/Closed): ");
            if (Enum.TryParse<LeadStatus>(Console.ReadLine(), out LeadStatus status))
            {
                await service.UpdateStatusAsync(leadId, status);
                Console.WriteLine("Updated.");
            }
            else
            {
                Console.WriteLine("Invalid status.");
            }
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

async Task ReportsMenu(VehicleRepoService vService, LeadRepoService lService)
{
    var (totalValue, avgPrice, count) = await vService.GetStockSummaryAsync();
    Console.WriteLine($"\nStock: {count} vehicles, total {totalValue:N0} TL, average {avgPrice:N0} TL");

    var stats = await lService.GetStatisticsAsync();
    Console.WriteLine("\nLead statistics:");
    foreach (var kvp in stats)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }
}