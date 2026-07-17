using System;
using System.Collections.Generic;

List<Vehicle> vehicles = new List<Vehicle>();

vehicles.Add(new Vehicle
{
    Id = "bmw-x5",
    Brand = "BMW",
    Model = "X5",
    Year = 2022,
    Mileage = 31000,
    BodyType = "SUV",
    FuelType = "Gasoline",
    Price = 5850000,
    ForSale = true
});

vehicles.Add(new Vehicle
{
    Id = "mercedes-e200",
    Brand = "Mercedes",
    Model = "E200",
    Year = 2021,
    Mileage = 42000,
    BodyType = "Sedan",
    FuelType = "Hybrid",
    Price = 4420000,
    ForSale = true
});

vehicles.Add(new Vehicle
{
    Id = "audi-q8",
    Brand = "Audi",
    Model = "Q8",
    Year = 2023,
    Mileage = 12000,
    BodyType = "SUV",
    FuelType = "Gasoline",
    Price = 6250000,
    ForSale = true
});

vehicles.Add(new Vehicle
{
    Id = "porsche-macan",
    Brand = "Porsche",
    Model = "Macan",
    Year = 2020,
    Mileage = 55000,
    BodyType = "SUV",
    FuelType = "Gasoline",
    Price = 5300000,
    ForSale = true
});

vehicles.Add(new Vehicle
{
    Id = "volvo-xc90",
    Brand = "Volvo",
    Model = "XC90",
    Year = 2021,
    Mileage = 38000,
    BodyType = "SUV",
    FuelType = "Diesel",
    Price = 4760000,
    ForSale = true
});

vehicles.Add(new Vehicle
{
    Id = "range-sport",
    Brand = "Range Rover",
    Model = "Sport",
    Year = 2022,
    Mileage = 20000,
    BodyType = "SUV",
    FuelType = "Diesel",
    Price = 6900000,
    ForSale = true
});

foreach (Vehicle v in vehicles)
{
    Console.WriteLine(v.Summary());
    Console.WriteLine($"Age: {v.GetAge()} years");
    Console.WriteLine(v);
    Console.WriteLine();
}