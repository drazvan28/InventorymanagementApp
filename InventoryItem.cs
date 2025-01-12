using System;

namespace RetailInventoryApp.Models
{
    public class InventoryItem : Product
    {
        public DateTime ExpirationDate { get; set; }

        // Constructor to initialize InventoryItem
        public InventoryItem(int productId, string name, decimal price, DateTime expirationDate)
            : base(productId, name, price)
        {
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return $"{base.ToString()},{ExpirationDate:yyyy-MM-dd}";
        }
    }
}