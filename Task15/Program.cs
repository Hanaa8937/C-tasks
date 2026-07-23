using System;
using System.Threading.Tasks;
using System.Diagnostics;

// --- Simulated async methods ---
async Task<string> GetVehiclesAsync()
{
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Fetching vehicles...");
    await Task.Delay(2000);
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Vehicles fetched!");
    return "vehicles";
}

async Task<string> SearchVehicleAsync(string term)
{
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Searching for '{term}'...");
    await Task.Delay(1000);
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Search complete!");
    return "search result";
}

async Task<string> SaveVehicleAsync(Vehicle vehicle)
{
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Saving {vehicle.Brand} {vehicle.Model}...");
    await Task.Delay(1500);
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Vehicle saved!");
    return "saved";
}

async Task<string> CreateLeadAsync(Lead lead)
{
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Creating lead {lead.Name}...");
    await Task.Delay(1000);
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Lead created!");
    return "lead created";
}

async Task<string> GenerateReportAsync()
{
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Generating report...");
    await Task.Delay(3000);
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Report generated!");
    return "report";
}

// --- Test data ---
Vehicle v1 = new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5);
Lead lead1 = new Lead("lead-1", "Ahmet Yilmaz", "0555-111-2233", "bmw-x5", LeadStatus.New);

// --- Sequential run ---
Console.WriteLine("=== SEQUENTIAL RUN ===");
Stopwatch stopwatch = Stopwatch.StartNew();

await GetVehiclesAsync();
await SearchVehicleAsync("BMW");
await SaveVehicleAsync(v1);
await CreateLeadAsync(lead1);
await GenerateReportAsync();

stopwatch.Stop();
Console.WriteLine($"Sequential run: {stopwatch.Elapsed.TotalSeconds:F1} seconds\n");

// --- Parallel run ---
Console.WriteLine("=== PARALLEL RUN ===");
stopwatch.Restart();

Task<string> t1 = GetVehiclesAsync();
Task<string> t2 = SearchVehicleAsync("BMW");
Task<string> t3 = SaveVehicleAsync(v1);
Task<string> t4 = CreateLeadAsync(lead1);
Task<string> t5 = GenerateReportAsync();

await Task.WhenAll(t1, t2, t3, t4, t5);

stopwatch.Stop();
Console.WriteLine($"Parallel run: {stopwatch.Elapsed.TotalSeconds:F1} seconds");