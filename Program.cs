using System;
using System.Globalization;
using SimpleWarehouse.Entities;

namespace SimpleWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p;
            Console.WriteLine();
            Console.WriteLine("Enter product name");
            string name = (Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Enter the Price");
            double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.WriteLine();
            Console.WriteLine("Enter the quantity");
            int quantity = int.Parse(Console.ReadLine());
            p = new Product(name, price, quantity);

            while (true)
            {
                Console.WriteLine("1 - Add Stock , 2 - Remove Stock, 3 - Update Price, 4 - Exit");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.Write("Enter the quantity to be added to stock: ");
                    int qte = int.Parse(Console.ReadLine());
                    p.AddProducts(qte);
                    Console.WriteLine(p);
                }
                else if (option == "2")
                {
                    Console.Write("Enter the quantity to be removed from stock: ");
                    int qte = int.Parse(Console.ReadLine());
                    p.RemoveProducts(qte);
                    Console.WriteLine(p);
                }
                else if (option == "3")
                {
                    Console.WriteLine("Enter the new price value.");
                    double newprice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    p.UpdatePrice(newprice);
                    Console.WriteLine(p);
                }
                else 
                {
                    break;
                }

            }



        }

    }
}