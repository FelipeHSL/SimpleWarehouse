using SimpleWarehouse.Entities;
using SimpleWarehouse.Services;
using System;
using System.ComponentModel;
using System.Globalization;

namespace SimpleWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            IWarehouseService warehouse = new WarehouseService();
            List<Product> inventory = new List<Product>();

            Console.WriteLine("--- SIMPLE WAREHOUSE INITIALIZED ---");

            Console.Write("Enter the number of products you wish to register: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i}");
                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Product Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Amount: ");
                int quantity = int.Parse(Console.ReadLine());



                Console.Write("What type of product do you wish to add? 1 for Perishable and 2 for Imported: ");
                char p = char.Parse(Console.ReadLine());

                if (p == '1')
                {

                    // 1. Instantiating the Perishable product
                    Console.Write("Due Date (DD/MM/YYYY): ");
                    DateTime expirationDate = DateTime.Parse(Console.ReadLine());
                    warehouse.AddProduct(new PerishableProduct(id, name, price, quantity, expirationDate));
                }
                else if (p == '2')
                {
                    // 3. Instantiating the imported product
                    Console.Write("Enter the Fee Amount: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    warehouse.AddProduct(new ImportedProduct(id, name, price, quantity, customsFee));
                }
            }


            // Displaying products and calculating the total value with colors and alerts.
            double totalValueAllStock = 0.0;

            Console.WriteLine("\n Updated Inventory Report:");
            foreach (Product prod in warehouse.GetInventory())
            {
                double totalProd = prod.TotalValueInStock();
                totalValueAllStock += totalProd;

                // If it is perishable, check the days to apply the alert color.
                if (prod is PerishableProduct perishable)
                {
                    int daysRemaining = perishable.DaysUntilExpiry();

                    if (daysRemaining < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Red if expired
                    }
                    else if (daysRemaining <= 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Yellow if won within 7 days
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Green if everything is okay
                    }
                    

                    // Prints the product line (with the color already applied, if perishable)
                    Console.WriteLine(prod.ToString() + $" | Total Inventory Value: ${totalProd.ToString("F2")}");

                    // IMPORTANT: Resets the color to the console default.
                    Console.ResetColor();
                }

                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"TOTAL WAREHOUSE VALUE: ${totalValueAllStock.ToString("F2")}");
                Console.WriteLine("----------------------------------------");





            }

        }
    }
}
