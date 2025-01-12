using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RetailInventoryApp.Models;

namespace InventoryManagementApp
{
    public class ProductService
    {
        private readonly List<Product> _products;
        private readonly string _filePath;

        public ProductService(string filePath)
        {
            _products = new List<Product>();
            _filePath = filePath;
            LoadData(); // Load data on initialization
        }

        // Add a product to the list
        public void AddProduct(Product product)
        {
            _products.Add(product);
            SaveData();
        }

        // Display all products
        public void DisplayProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }

        // Update a product based on productId
        public void UpdateProduct(int productId, string name, int quantity, decimal price)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                product.Name = name;
                product.Quantity = quantity;
                product.Price = price;
                SaveData();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Delete a product
        public void DeleteProduct(int productId)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
                SaveData();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Inbound stock (add quantity)
        public void InboundStock(int productId, int quantity)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                product.Quantity += quantity;
                SaveData();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Outbound stock (remove quantity)
        public void OutboundStock(int productId, int quantity)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                if (product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    SaveData();
                }
                else
                {
                    Console.WriteLine("Not enough stock.");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Public Save data method
        public void SaveData()
        {
            var lines = _products.Select(p => p.ToString()).ToList();
            File.WriteAllLines(_filePath, lines);
        }

        // Public Load data method
        public void LoadData()
        {
            if (File.Exists(_filePath))
            {
                var lines = File.ReadAllLines(_filePath);
                foreach (var line in lines.Skip(1)) // Skip header
                {
                    var columns = line.Split(',');
                    if (columns.Length >= 4)
                    {
                        // Handle different types of products
                        int productId = int.Parse(columns[0]);
                        string name = columns[1];
                        decimal price = decimal.Parse(columns[2]);
                        int quantity = int.Parse(columns[3]);

                        // Add appropriate type of product (InventoryItem)
                        if (columns.Length == 5) // InventoryItem
                        {
                            DateTime expirationDate = DateTime.Parse(columns[4]);
                            _products.Add(new InventoryItem(productId, name, price, expirationDate));
                        }
                    }
                }
            }
        }
    }
}