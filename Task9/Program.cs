using System;
using System.Collections.Generic;

List<Vehicle> vehicles = new List<Vehicle>();

vehicles.Add(new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, "Gasoline", true, 5));
vehicles.Add(new Suv("range-sport", "Range Rover", "Sport", 2022, 6900000, 20000, "Diesel", true, 5));
vehicles.Add(new Sedan("mercedes-e200", "Mercedes", "E200", 2021, 4420000, 42000, "Hybrid", 540));
vehicles.Add(new Sedan("audi-a6", "Audi", "A6", 2022, 4900000, 25000, "Gasoline", 530));
vehicles.Add(new SportsCar("porsche-911", "Porsche", "911", 2023, 8900000, 8000, "Gasoline", 450, 3.8));
vehicles.Add(new SportsCar("audi-r8", "Audi", "R8", 2021, 9500000, 15000, "Gasoline", 570, 3.4));

foreach (Vehicle v in vehicles)
{
    Console.WriteLine(v.Summary());
    Console.WriteLine(v.Introduce());   // each type prints its own version automatically
    Console.WriteLine();
}