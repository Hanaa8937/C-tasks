using System;

double[] prices = { 5850000, 4420000, 6250000, 5300000, 4760000, 6900000 };

// for loop — numbered list
Console.WriteLine("=== VEHICLE PRICES ===");
for (int i = 0; i < prices.Length; i++)
{
    Console.WriteLine($"{i + 1}. {prices[i]:N0} TL");
    }

    // foreach loop — calculations
    double total = 0;
    double max = prices[0];
    double min = prices[0];

    foreach (double price in prices)
    {
        total += price;
            if (price > max) max = price;
                if (price < min) min = price;
                }

                double average = total / prices.Length;

                Console.WriteLine("\n=== STOCK REPORT ===");
                Console.WriteLine($"Total number of vehicles: {prices.Length}");
                Console.WriteLine($"Total stock value: {total:N0} TL");
                Console.WriteLine($"Average price: {average:N0} TL");
                Console.WriteLine($"Most expensive: {max:N0} TL");
                Console.WriteLine($"Cheapest: {min:N0} TL");

                // while loop — repeated budget check
                Console.WriteLine("\nEnter a budget to see how many vehicles fit (enter 0 to stop):");
                double budget = -1;
                while (budget != 0)
                {
                    Console.Write("Budget: ");
                        budget = double.Parse(Console.ReadLine() ?? "0");

                            if (budget == 0)
                                {
                                        Console.WriteLine("Exiting budget checker.");
                                                break;
                                                    }

                                                        int count = 0;
                                                            foreach (double price in prices)
                                                                {
                                                                        if (price <= budget) count++;
                                                                            }
                                                                                Console.WriteLine($"{count} vehicle(s) fit this budget.\n");
                                                                                }