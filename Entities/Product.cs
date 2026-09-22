using System;
using System.Globalization;

namespace SimpleWarehouse.Entities
{
public abstract class Product
    {
        // Encapsulation: the properties have a 'private set' so that no 
        // external class can modify the data without going through the business rules.

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; protected set; } // 'protected' allows subclasses to change the price.
        public int Quantity { get; private set; }

        // Base class default constructor
        protected Product(int id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // Method to add items to inventory
        public void AddProducts(int quantity)
        {
            if (quantity <= 0)
            {
                
                throw new ArgumentException("The entry amount must be greater than zero.");
            }
            Quantity += quantity;
        }

        // Method for recording stock issues
        public void RemoveProducts(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("The outbound quantity must be greater than zero.");
            }
            if (Quantity < quantity)
            {
                throw new InvalidOperationException("Insufficient stock to process the issue.");
            }
            Quantity -= quantity;
        }

        // Abstract method: forces every subclass to implement its own final price rule.


        public abstract double TotalValueInStock();

        // Overriding ToString to display the data cleanly in the console.
        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Base Price: ${Price.ToString("F2",CultureInfo.InvariantCulture)} | Stock: {Quantity} unidades";
        }
    }
}
