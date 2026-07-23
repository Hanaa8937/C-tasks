using System;
using System.Collections.Generic;
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

    public async Task DeleteVehicleAsync(string id)
    {
        Vehicle? vehicle = await repository.GetAsync(id);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException($"No vehicle found with ID '{id}'.");
        }
        await repository.DeleteAsync(id);
    }
}