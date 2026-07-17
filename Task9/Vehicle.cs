using System;

public class Vehicle
{
    public readonly string Id;
    public string Brand;
    public string Model;
    public int Year;
    public string BodyType;
    public string FuelType;
    public bool ForSale;

    private double price;
    private int mileage;

    public readonly DateTime CreatedAt;

    public Vehicle(string id, string brand, string model, int year, double price, int mileage, string bodyType, string fuelType)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
        Mileage = mileage;
        BodyType = bodyType;
        FuelType = fuelType;
        CreatedAt = DateTime.Now;
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                price = 0;
            }
            else
            {
                price = value;
            }
        }
    }

    public int Mileage
    {
        get { return mileage; }
        set
        {
            if (value < 0) return;
            if (value < mileage) return;
            mileage = value;
        }
    }

    public string Summary()
    {
        return $"{Year} {Brand} {Model} — {Price:N0} TL";
    }

    public int GetAge()
    {
        return DateTime.Now.Year - Year;
    }

    public bool FitsBudget(double budget)
    {
        return Price <= budget;
    }

    // virtual means child classes are allowed to replace this with their own version
    public virtual string Introduce()
    {
        return "This is a vehicle.";
    }

    public override string ToString()
    {
        return $"[{Id}] {Brand} {Model} ({Year}) - {Mileage} km - {BodyType}/{FuelType} - {Price:N0} TL";
    }
}