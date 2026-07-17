using System;

public class Lead : IPrintable, ISearchable
{
    public string Id;
    public string Name;
    public string Phone;
    public string InterestedVehicleId;
    public string Status;

    public Lead(string id, string name, string phone, string interestedVehicleId, string status)
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
        Console.WriteLine($"[{Id}] {Name} - {Phone} - Interested in: {InterestedVehicleId} - Status: {Status}");
    }

    public string ShortSummary()
    {

        return $"{Name} ({Status})";
    }
    public override string ToString()
{
    return $"[{Id}] {Name} - {Phone} - Interested in: {InterestedVehicleId} - Status: {Status}";
}
}