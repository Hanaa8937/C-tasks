using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class VehicleRepoService
{
    private IRepository<Vehicle> repository;

    public VehicleRepoService(IRepository<Vehicle> repository)
    {
        this.repository = repository;
    }

    public async Task AddVehicleAsync(Vehicle vehicle)
    {
        Vehicle? existing = await repository.GetAsync(vehicle.Id);
        if (existing != null)
        {
            throw new ArgumentException($"A vehicle with ID '{vehicle.Id}' already exists.");
        }
        await repository.AddAsync(vehicle);
    }

    public async Task<List<Vehicle>> ListAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<List<Vehicle>> SearchAsync(string term)
    {
        return await repository.FilterAsync(v => v.Search(term));
    }

    public async Task<List<Vehicle>> FilterAsync(BodyType? bodyType, FuelType? fuelType, double? minPrice, double? maxPrice)
    {
        return await repository.FilterAsync(v =>
            (bodyType == null || v.BodyType == bodyType) &&
            (fuelType == null || v.FuelType == fuelType) &&
            (minPrice == null || v.Price >= minPrice) &&
            (maxPrice == null || v.Price <= maxPrice));
    }

    public async Task UpdatePriceAsync(string id, double newPrice)
    {
        Vehicle? vehicle = await repository.GetAsync(id);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException($"No vehicle found with ID '{id}'.");
        }
        vehicle.Price = newPrice;
        await repository.UpdateAsync(vehicle);
    }

    public async Task DeleteVehicleAsync(string id)
    {
        Vehicle? vehicle = await repository.GetAsync(id);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException($"No vehicle found with ID '{id}'.");
        }
        await repository.DeleteAsync(id);
    }

    public async Task<(double totalValue, double avgPrice, int count)> GetStockSummaryAsync()
    {
        List<Vehicle> vehicles = await repository.GetAllAsync();
        if (vehicles.Count == 0) return (0, 0, 0);
        return (vehicles.Sum(v => v.Price), vehicles.Average(v => v.Price), vehicles.Count);
    }
}