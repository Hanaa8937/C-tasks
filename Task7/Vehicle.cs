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

    // Full constructor — takes every property
    public Vehicle(string id, string brand, string model, int year, double price, int mileage, string bodyType, string fuelType)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;       // goes through the validation below
        Mileage = mileage;   // goes through the validation below
        BodyType = bodyType;
        FuelType = fuelType;
        CreatedAt = DateTime.Now;
    }

    // Simple constructor — just brand and model, everything else defaults
    public Vehicle(string brand, string model)
    {
        Id = Guid.NewGuid().ToString();
        Brand = brand;
        Model = model;
        Year = DateTime.Now.Year;
        Price = 0;
        Mileage = 0;
        BodyType = "Unknown";
        FuelType = "Unknown";
        CreatedAt = DateTime.Now;
    }

    // Price property with validation
    public double Price
    {
        get { return price; }
        set
        {
            double oldPrice = price;
            if (value < 0)
            {
                price = 0;
            }
            else
            {
                price = value;
            }

            if (oldPrice != price)
            {
                Console.WriteLine($"Price updated: {oldPrice:N0} → {price:N0}");
            }
        }
    }

    // Mileage property with validation
    public int Mileage
    {
        get { return mileage; }
        set
        {
            if (value < 0)
            {
                return; // ignore negative values
            }
            if (value < mileage)
            {
                return; // can't roll back the odometer
            }
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

    public override string ToString()
    {
        return $"[{Id}] {Brand} {Model} ({Year}) - {Mileage} km - {BodyType}/{FuelType} - {Price:N0} TL";
    }
}