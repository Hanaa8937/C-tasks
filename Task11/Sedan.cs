using System;

public class Sedan : Vehicle
{
    public int TrunkVolume;

    public Sedan(string id, string brand, string model, int year, double price, int mileage, string fuelType, int trunkVolume)
        : base(id, brand, model, year, price, mileage, "Sedan", fuelType)
    {
        TrunkVolume = trunkVolume;
    }

    public bool IsBusinessCar()
    {
        return TrunkVolume > 400;
    }

    public override string Introduce()
    {
        return $"This is a sedan. Trunk: {TrunkVolume} liters";
    }
}