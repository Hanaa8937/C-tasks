using System;

public class TourScene : IIdentifiable
{
    public string Id;
    public LocalizedText Name = new LocalizedText();
    public string VehicleId;
    public List<string> Hotspots = new List<string>();
    public VehicleStatus Status;

    string IIdentifiable.Id => Id;

    public TourScene(string id, string vehicleId)
    {
        Id = id;
        VehicleId = vehicleId;
        Status = VehicleStatus.Draft;
    }
}