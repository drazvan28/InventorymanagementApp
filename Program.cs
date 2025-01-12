using RetailInventoryApp.Services;

namespace InventoryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "products.csv";
            var productService = new ProductService(filePath);
            var dataHandlers = new DataHandlers(productService);

            while (true)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Inbound Stock");
                Console.WriteLine("6. Outbound Stock");
                Console.WriteLine("7. Save to CSV");
                Console.WriteLine("8. Load from CSV");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        dataHandlers.AddNewProduct();
                        break;

                    case "2":
                        dataHandlers.DisplayAllProducts();
                        break;

                    case "3":
                        dataHandlers.UpdateExistingProduct();
                        break;

                    case "4":
                        dataHandlers.DeleteProduct();
                        break;

                    case "5":
                        dataHandlers.InboundStock();
                        break;

                    case "6":
                        dataHandlers.OutboundStock();
                        break;

                    case "7":
                        productService.SaveData();
                        Console.WriteLine("Data saved.");
                        break;

                    case "8":
                        productService.LoadData();
                        Console.WriteLine("Data loaded.");
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}