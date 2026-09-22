namespace SimpleWarehouse.Entities;

public class ImportedProduct : Product
{
    public double CustomsFee { get; private set; } 

    
    public ImportedProduct(int id, string name, double price, int quantity, double customsFee = 0.0)
        : base(id, name, price, quantity)
    {
        CustomsFee = customsFee;
    }

    // Polymorphism: The inventory value of the imported item is the sum of the base price, a 10% standard tax, and an extra customs fee.
    public override double TotalValueInStock()
    {
        double importTax = Price * 0.10; // 10% standard fee
        double finalPrice = Price + importTax + CustomsFee;
        return finalPrice * Quantity;
    }

    public override string ToString()
    {
        return base.ToString() + $" (Imported – Includes 10% tax)";
    }
}