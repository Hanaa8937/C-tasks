using System;

Vehicle v1 = new Suv("bmw-x5", "BMW", "X5", 2022, 5850000, 31000, FuelType.Gasoline, true, 5);

v1.Hero.Translations["en"] = "Commanding family SUV with premium comfort and high trust signals.";
v1.Hero.Translations["tr"] = "Premium konfor ve güçlü güven sinyalleri sunan iddialı aile SUV'u.";
v1.Hero.Translations["fa"] = "یک شاسی بلند خانوادگی قدرتمند با راحتی لوکس و نشانه های اعتماد بالا.";

Console.WriteLine("--- Testing supported languages ---");
Console.WriteLine($"EN: {v1.Hero.GetText("en")}");
Console.WriteLine($"TR: {v1.Hero.GetText("tr")}");
Console.WriteLine($"FA: {v1.Hero.GetText("fa")}");

Console.WriteLine("\n--- Testing fallback (unsupported language) ---");
Console.WriteLine($"JP: {v1.Hero.GetText("jp")}");

Console.WriteLine("\n--- Asking the user for a language ---");
Console.Write("Enter a language code (en/tr/fa/ar/ru/de): ");
string userLang = Console.ReadLine() ?? "en";
Console.WriteLine($"Description: {v1.Hero.GetText(userLang)}");