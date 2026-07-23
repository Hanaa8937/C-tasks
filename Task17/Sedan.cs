using System;

public class Sedan : Vehicle
{
    public int TrunkVolume;

    public Sedan(string id, string brand, string model, int year, double price, int mileage, FuelType fuelType, int trunkVolume)
        : base(id, brand, model, year, price, mileage, BodyType.Sedan, fuelType)
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