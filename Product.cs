using System;

namespace RetailInventoryApp.Models
{
    public abstract class Product
    {
        private int _productId;
        private string _name;
        private decimal _price;
        private int _quantity;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        // Constructor for the base Product class
        public Product(int productId, string name, decimal price)
        {
            _productId = productId;
            _name = name;
            _price = price;
            _quantity = 0; // Default to 0 quantity
        }

        public override string ToString()
        {
            return $"{ProductId},{Name},{Price},{Quantity}";
        }
    }
}