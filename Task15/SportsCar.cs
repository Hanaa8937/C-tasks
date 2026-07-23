using System;

public class SportsCar : Vehicle
{
    public int Horsepower;
    public double ZeroToHundred;

    public SportsCar(string id, string brand, string model, int year, double price, int mileage, FuelType fuelType, int horsepower, double zeroToHundred)
        : base(id, brand, model, year, price, mileage, BodyType.Coupe, fuelType)
    {
        Horsepower = horsepower;
        ZeroToHundred = zeroToHundred;
    }

    public bool IsFast()
    {
        return ZeroToHundred < 5;
    }

    public override string Introduce()
    {
        return $"This is a sports car. 0-100: {ZeroToHundred} seconds";
    }
}