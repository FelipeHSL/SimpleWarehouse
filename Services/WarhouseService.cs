using System.Collections.Generic;
using SimpleWarehouse.Entities;

namespace SimpleWarehouse.Services
{
    public class WarehouseService : IWarehouseService
    {
        // The inventory list is now protected within the service!
        private readonly List<Product> _inventory = new List<Product>();

        public void AddProduct(Product product)
        {
            _inventory.Add(product);
        }

        public List<Product> GetInventory()
        {
            return _inventory;
        }

        public double CalculateTotalInventoryValue()
        {
            double total = 0.0;
            foreach (var prod in _inventory)
            {
                total += prod.TotalValueInStock();
            }
            return total;
        }
    }
}
