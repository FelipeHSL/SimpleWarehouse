using System;
using System.Globalization;

namespace SimpleWarehouse.Entities
{
    class Product
    {
        private string _name; 
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        public Product(string name, double price, int quantity)
        {
            _name = name;
            Price = price;
            Quantity = quantity;

        }

        public string Name
        {
            get { return _name; }
            set { if (value != null && value.Length > 3) _name = value; }
        }

        public void UpdatePrice(double newPrice)
        {
            if (newPrice > 0 ) Price = newPrice;

        }

        public double TotalValueInStock()
        {
            return Price * Quantity;
        }

        public void AddProducts (int quantity)
        {
            Quantity += quantity;

        }

        public void RemoveProducts(int quantity)
        {
            if (quantity <= Quantity)
            {
                Quantity -= quantity;
            }
            else { Console.WriteLine("Error: Insufficient stock!"); }
            
           
        }

        public override string ToString()
        {
            return $"Product: {Name} | Price: {Price.ToString("f2",CultureInfo.InvariantCulture)} | Stock: {Quantity} | Total Value: $ {TotalValueInStock().ToString("f2",CultureInfo.InvariantCulture)}";
        }
    }
}
