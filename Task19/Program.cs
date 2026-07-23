using System;

GalleryManager gallery = new GalleryManager();

gallery.AddVehicle(new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5));
gallery.AddVehicle(new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, FuelType.Hybrid, 540));

Console.WriteLine("--- Adding leads ---");
Lead lead1 = gallery.AddLead("Ahmet Yilmaz", "0555-111-2233", "bmw-x5", LeadStatus.New);
Lead lead2 = gallery.AddLead("Elif Kaya", "0555-444-5566", "bmw-x5", LeadStatus.Qualified);
Lead lead3 = gallery.AddLead("Mert Demir", "0555-777-8899", "mercedes-e200", LeadStatus.New);

Console.WriteLine($"{lead1.Id} created for {lead1.InterestedVehicle?.Brand} {lead1.InterestedVehicle?.Model}");
Console.WriteLine($"{lead2.Id} created for {lead2.InterestedVehicle?.Brand} {lead2.InterestedVehicle?.Model}");
Console.WriteLine($"{lead3.Id} created for {lead3.InterestedVehicle?.Brand} {lead3.InterestedVehicle?.Model}");

Console.WriteLine("\n--- Leads for bmw-x5 ---");
foreach (Lead l in gallery.GetVehicleLeads("bmw-x5"))
{
    Console.WriteLine(l.ShortSummary());
}

Console.WriteLine("\n--- Lead statistics ---");
gallery.LeadStatistics();

Console.WriteLine("\n--- Testing validation: lead for non-existent vehicle ---");
try
{
    gallery.AddLead("Fake Person", "0000-000-0000", "tesla-s", LeadStatus.New);
}
catch (VehicleNotFoundException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\n--- Testing validation: removing a vehicle with leads ---");
try
{
    gallery.RemoveVehicle("bmw-x5");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}