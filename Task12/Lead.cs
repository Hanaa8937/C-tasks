using System;

public class Lead : IPrintable, ISearchable
{
    public string Id;
    public string Name;
    public string Phone;
    public string InterestedVehicleId;
    public LeadStatus Status;

    public Lead(string id, string name, string phone, string interestedVehicleId, LeadStatus status)
    {
        Id = id;
        Name = name;
        Phone = phone;
        InterestedVehicleId = interestedVehicleId;
        Status = status;
    }

    public bool Search(string term)
    {
        return Name.ToLower().Contains(term.ToLower());
    }

    public void Print()
    {
        Console.WriteLine(this);
    }

    public string ShortSummary()
    {
        return $"{Name} ({Status})";
    }

    public override string ToString()
    {
        return $"[{Id}] {Name} - {Phone} - Interested in: {InterestedVehicleId} - Status: {Status}";
    }

    // Checks if moving from the current status to a new one is allowed
    public bool CanTransitionTo(LeadStatus newStatus)
    {
        if (Status == LeadStatus.New && newStatus == LeadStatus.Qualified) return true;
        if (Status == LeadStatus.Qualified && newStatus == LeadStatus.Nurturing) return true;
        if (Status == LeadStatus.Nurturing && newStatus == LeadStatus.Closed) return true;
        return false;
    }
}