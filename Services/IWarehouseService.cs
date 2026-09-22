using System.Collections.Generic;
using SimpleWarehouse.Entities;

namespace SimpleWarehouse.Services
{
    public interface IWarehouseService
    {
        void AddProduct(Product product);
        List<Product> GetInventory();
        double CalculateTotalInventoryValue();
    }
}
