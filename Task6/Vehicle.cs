using System;

public class Vehicle
{
    public string Id;
    public string Brand;
    public string Model;
    public int Year;
    public int Mileage;
    public string BodyType;
    public string FuelType;
    public double Price;
    public bool ForSale;

    // Returns a short one-line summary
    public string Summary()
    {
        return $"{Year} {Brand} {Model} — {Price:N0} TL";
    }

    // Works out how old the vehicle is
    public int GetAge()
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - Year;
    }

    // Checks if the vehicle fits inside a given budget
    public bool FitsBudget(double budget)
    {
        return Price <= budget;
    }

    // Overrides the built-in ToString() so printing the object looks nice
    public override string ToString()
    {
        return $"[{Id}] {Brand} {Model} ({Year}) - {Mileage} km - {BodyType}/{FuelType} - {Price:N0} TL";
    }
}