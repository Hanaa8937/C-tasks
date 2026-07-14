using System;

// Test the methods
Console.WriteLine(Helpers.FormatPrice(5850000));
Console.WriteLine(Helpers.FormatPrice(5850000, "EUR"));
Console.WriteLine(Helpers.MileageStatus(15000));
Console.WriteLine(Helpers.MileageStatus(75000));
Console.WriteLine(Helpers.VehicleSummary("BMW", "X5", 2022));
Console.WriteLine(Helpers.IsPriceInRange(5850000, 5000000, 6000000));
Console.WriteLine(Helpers.YearDifference(2022));
Console.WriteLine(Helpers.DiscountedFinalPrice(5850000, 10));

static class Helpers
{
    public static string FormatPrice(double price)
    {
        return $"{price:N0} TL";
    }

    public static string FormatPrice(double price, string currency)
    {
        return $"{price:N0} {currency}";
    }

    public static string MileageStatus(int mileage)
    {
        if (mileage <= 30000) return "Low";
        if (mileage <= 60000) return "Medium";
        return "High";
    }

    public static string VehicleSummary(string brand, string model, int year)
    {
        return $"{year} {brand} {model}";
    }

    public static bool IsPriceInRange(double price, double min, double max)
    {
        return price >= min && price <= max;
    }

    public static int YearDifference(int vehicleYear)
    {
        return DateTime.Now.Year - vehicleYear;
    }

    public static double DiscountedFinalPrice(double price, double discountPercent)
    {
        return price - (price * discountPercent / 100);
    }
}