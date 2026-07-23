using System;
using System.Collections.Generic;
using System.Linq;

public class GalleryManager
{
    private List<Vehicle> vehicles = new List<Vehicle>();
    private List<Lead> leads = new List<Lead>();
    private int leadCounter = 1;

    public void AddVehicle(Vehicle vehicle)
    {
        if (vehicles.Any(v => v.Id == vehicle.Id))
        {
            throw new ArgumentException($"A vehicle with ID '{vehicle.Id}' already exists.");
        }
        vehicles.Add(vehicle);
    }

    public Lead AddLead(string name, string phone, string vehicleId, LeadStatus status)
    {
        Vehicle? vehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException($"Cannot create lead: no vehicle found with ID '{vehicleId}'.");
        }

        string leadId = $"L-{leadCounter:D4}";
        leadCounter++;

        Lead lead = new Lead(leadId, name, phone, vehicleId, status);
        lead.InterestedVehicle = vehicle;

        leads.Add(lead);
        vehicle.Leads.Add(lead);

        return lead;
    }

    public void RemoveVehicle(string id)
    {
        Vehicle? vehicle = vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException($"No vehicle found with ID '{id}'.");
        }

        if (vehicle.Leads.Count > 0)
        {
            throw new InvalidOperationException(
                $"Cannot remove vehicle '{id}': it has {vehicle.Leads.Count} linked lead(s).");
        }

        vehicles.Remove(vehicle);
    }

    public List<Lead> GetVehicleLeads(string vehicleId)
    {
        Vehicle? vehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException($"No vehicle found with ID '{vehicleId}'.");
        }
        return vehicle.Leads;
    }

    public void LeadStatistics()
    {
        foreach (Vehicle v in vehicles)
        {
            Console.WriteLine($"{v.Brand} {v.Model}: {v.Leads.Count} lead(s)");
        }
    }
}