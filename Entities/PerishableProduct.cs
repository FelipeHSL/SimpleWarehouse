namespace SimpleWarehouse.Entities;

public class PerishableProduct : Product
{
    public DateTime ExpirationDate { get; private set; }

    public PerishableProduct(int id, string name, double price, int quantity, DateTime expirationDate)
        : base(id, name, price, quantity)
    {
        ExpirationDate = expirationDate;
    }

    // Polymorphism: Calculates the total stock value, applying a 5% discount if there are fewer than 7 days remaining until expiration.
    public override double TotalValueInStock()
    {
        double currentPrice = Price;
        int daysToExpire = (ExpirationDate - DateTime.Now).Days;

        if (daysToExpire >= 0 && daysToExpire <= 7)
        {
            currentPrice -= Price * 0.05; // Apply the 5% discount
        }

        return currentPrice * Quantity;
    }

    public int DaysUntilExpiry()
    {
        return (ExpirationDate.Date - DateTime.Now.Date).Days;
    }

    public override string ToString()
    {
        int daysRemaining = DaysUntilExpiry();
        string DueDateStatus;

        // Logic to make the report text intelligent
        if (daysRemaining < 0)
        {
            DueDateStatus = $"Overdue by {Math.Abs(daysRemaining)} days";
        }
        else if (daysRemaining == 0)
        {
            DueDateStatus = "Due today!";
        }
        else
        {
            DueDateStatus = $"{daysRemaining} days remaining until due";
        }

        return base.ToString()
            + $" | Expires on: {ExpirationDate.ToString("dd/MM/yyyy")}"
            + $" | ({DueDateStatus})";
    }


}