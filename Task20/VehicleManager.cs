using System;
using System.Collections.Generic;

public class VehicleManager
{
    private Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        if (string.IsNullOrEmpty(vehicle.Id))
        {
            throw new ArgumentException("Vehicle ID cannot be empty.");
        }
        if (vehicles.ContainsKey(vehicle.Id))
        {
            throw new ArgumentException($"A vehicle with ID '{vehicle.Id}' already exists.");
        }
        vehicles.Add(vehicle.Id, vehicle);
    }

    public Vehicle FindVehicle(string id)
    {
        if (!vehicles.ContainsKey(id))
        {
            throw new VehicleNotFoundException($"No vehicle found with ID '{id}'.");
        }
        return vehicles[id];
    }

    public void UpdatePrice(string id, double newPrice)
    {
        if (newPrice < 0 || newPrice > 100000000)
        {
            throw new InvalidPriceException($"Price {newPrice:N0} is out of the allowed range.");
        }
        Vehicle v = FindVehicle(id);
        v.Price = newPrice;
    }

    public void UpdateStatus(string id, VehicleStatus newStatus)
    {
        Vehicle v = FindVehicle(id);

        bool validTransition =
            (v.Status == VehicleStatus.Draft && newStatus == VehicleStatus.Published) ||
            (v.Status == VehicleStatus.Published && newStatus == VehicleStatus.Archived);

        if (!validTransition)
        {
            throw new StatusTransitionException($"Cannot change status from {v.Status} to {newStatus}.");
        }
        v.Status = newStatus;
    }
}