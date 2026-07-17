using System;

public class Suv : Vehicle
{
    public bool IsAwd;
    public int SeatCount;

    // base(...) sends the shared info up to the Vehicle constructor
    public Suv(string id, string brand, string model, int year, double price, int mileage, string fuelType, bool isAwd, int seatCount)
        : base(id, brand, model, year, price, mileage, "SUV", fuelType)
    {
        IsAwd = isAwd;
        SeatCount = seatCount;
    }

    public bool IsOffRoadCapable()
    {
        return IsAwd;
    }

    // override replaces the base version with this one
    public override string Introduce()
    {
        string awdText = IsAwd ? "Yes" : "No";
        return $"This is an SUV. AWD: {awdText}";
    }
}