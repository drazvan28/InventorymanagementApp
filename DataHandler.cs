using System;
using RetailInventoryApp.Models;
using InventoryManagementApp;

namespace RetailInventoryApp.Services
{
    public class DataHandlers
    {
        private readonly ProductService _productService;

        public DataHandlers(ProductService productService)
        {
            _productService = productService;
        }

        public void AddNewProduct()
        {
            Console.WriteLine("Enter Product details: ");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Expiration Date (yyyy-MM-dd): ");
            DateTime expirationDate = DateTime.Parse(Console.ReadLine());

            var product = new InventoryItem(id, name, price, expirationDate);
            _productService.AddProduct(product);
        }

        public void DisplayAllProducts()
        {
            _productService.DisplayProducts();
        }

        public void UpdateExistingProduct()
        {
            Console.Write("Enter Product ID to update: ");
            int updateId = int.Parse(Console.ReadLine());
            Console.Write("New Name: ");
            string updateName = Console.ReadLine();
            Console.Write("New Quantity: ");
            int updateQuantity = int.Parse(Console.ReadLine());
            Console.Write("New Price: ");
            decimal updatePrice = decimal.Parse(Console.ReadLine());

            _productService.UpdateProduct(updateId, updateName, updateQuantity, updatePrice);
        }

        public void DeleteProduct()
        {
            Console.Write("Enter Product ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine());
            _productService.DeleteProduct(deleteId);
        }

        public void InboundStock()
        {
            Console.Write("Enter Product ID to inbound: ");
            int inboundId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to add: ");
            int inboundQuantity = int.Parse(Console.ReadLine());

            _productService.InboundStock(inboundId, inboundQuantity);
        }

        public void OutboundStock()
        {
            Console.Write("Enter Product ID to outbound: ");
            int outboundId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to remove: ");
            int outboundQuantity = int.Parse(Console.ReadLine());

            _productService.OutboundStock(outboundId, outboundQuantity);
        }
    }
}