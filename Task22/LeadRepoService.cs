using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class LeadRepoService
{
    private IRepository<Lead> leadRepo;
    private IRepository<Vehicle> vehicleRepo;
    private int counter = 1;

    public LeadRepoService(IRepository<Lead> leadRepo, IRepository<Vehicle> vehicleRepo)
    {
        this.leadRepo = leadRepo;
        this.vehicleRepo = vehicleRepo;
    }

    public async Task<Lead> CreateLeadAsync(string name, string phone, string vehicleId, LeadStatus status)
    {
        Vehicle? vehicle = await vehicleRepo.GetAsync(vehicleId);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException($"No vehicle found with ID '{vehicleId}'.");
        }

        string id = $"L-{counter:D4}";
        counter++;

        Lead lead = new Lead(id, name, phone, vehicleId, status);
        await leadRepo.AddAsync(lead);
        return lead;
    }

    public async Task<List<Lead>> ListAllAsync()
    {
        return await leadRepo.GetAllAsync();
    }

    public async Task UpdateStatusAsync(string leadId, LeadStatus newStatus)
    {
        Lead? lead = await leadRepo.GetAsync(leadId);
        if (lead == null)
        {
            throw new ArgumentException($"No lead found with ID '{leadId}'.");
        }
        lead.Status = newStatus;
        await leadRepo.UpdateAsync(lead);
    }

    public async Task<List<Lead>> FilterByVehicleAsync(string vehicleId)
    {
        return await leadRepo.FilterAsync(l => l.InterestedVehicleId == vehicleId);
    }

    public async Task<Dictionary<LeadStatus, int>> GetStatisticsAsync()
    {
        List<Lead> leads = await leadRepo.GetAllAsync();
        return leads.GroupBy(l => l.Status).ToDictionary(g => g.Key, g => g.Count());
    }
}