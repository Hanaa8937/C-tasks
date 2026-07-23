using System;

public class Vehicle : ISearchable, IPriceable, IPrintable
{
    public readonly string Id;
    public string Brand;
    public string Model;
    public int Year;
    public BodyType BodyType;
    public FuelType FuelType;
    public LocalizedText Hero = new LocalizedText();
    public VehicleStatus Status;

    private double price;
    private int mileage;

    public readonly DateTime CreatedAt;

    public Vehicle(string id, string brand, string model, int year, double price, int mileage, BodyType bodyType, FuelType fuelType)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
        Mileage = mileage;
        BodyType = bodyType;
        FuelType = fuelType;
        Status = VehicleStatus.Draft;
        CreatedAt = DateTime.Now;
    }

    public double Price
    {
        get { return price; }
        set { price = value < 0 ? 0 : value; }
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

    public virtual string Introduce()
    {
        return "This is a vehicle.";
    }

    public override string ToString()
    {
        return $"[{Id}] {Brand} {Model} ({Year}) - {Mileage} km - {BodyType}/{FuelType} - {Price:N0} TL";
    }

    public bool Search(string term)
    {
        string lowerTerm = term.ToLower();
        return Brand.ToLower().Contains(lowerTerm) || Model.ToLower().Contains(lowerTerm);
    }

    public double CalculatePrice()
    {
        return Price * 1.20;
    }

    public void ApplyDiscount(double percent)
    {
        Price = Price - (Price * percent / 100);
    }

    public void Print()
    {
        Console.WriteLine(this);
    }

    public string ShortSummary()
    {
        return $"{Brand} {Model} — {Price:N0} TL";
    }
}