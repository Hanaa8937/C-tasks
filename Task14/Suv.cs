using System;

public class Suv : Vehicle
{
    public bool IsAwd;
    public int SeatCount;

    public Suv(string id, string brand, string model, int year, double price, int mileage, FuelType fuelType, bool isAwd, int seatCount)
        : base(id, brand, model, year, price, mileage, BodyType.SUV, fuelType)
    {
        IsAwd = isAwd;
        SeatCount = seatCount;
    }

    public bool IsOffRoadCapable()
    {
        return IsAwd;
    }

    public override string Introduce()
    {
        string awdText = IsAwd ? "Yes" : "No";
        return $"This is an SUV. AWD: {awdText}";
    }
}