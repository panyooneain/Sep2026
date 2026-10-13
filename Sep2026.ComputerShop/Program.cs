
using System;
using System.Collections.Generic;

namespace ComputerShopManagementSystem
{
    class Program
    {
        static List<Product> products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Laptop",
                Brand = "ASUS",
                Price = 1500000,
                Quantity = 10
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Keyboard",
                Brand = "Logitech",
                Price = 45000,
                Quantity = 20
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Mouse",
                Brand = "HP",
                Price = 25000,
                Quantity = 15
            }
        };

        static int nextId = 4;

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine("  COMPUTER SHOP MANAGEMENT SYSTEM");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Sell Product");
                Console.WriteLine("7. Exit");
                Console.WriteLine("======================================");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;

                    case "2":
                        ViewProducts();
                        break;

                    case "3":
                        SearchProduct();
                        break;

                    case "4":
                        UpdateProduct();
                        break;

                    case "5":
                        DeleteProduct();
                        break;

                    case "6":
                        SellProduct();
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine(
                            "Thank you for using the system!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.WriteLine("\n=== Add Product ===");

            Console.Write("Product Name: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name is required.");
                Pause();
                return;
            }

            Console.Write("Brand: ");
            string brand = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(brand))
            {
                Console.WriteLine("Brand is required.");
                Pause();
                return;
            }

            Console.Write("Price (MMK): ");

            if (!decimal.TryParse(
                Console.ReadLine(), out decimal price) || price <= 0)
            {
                Console.WriteLine(
                    "Enter a valid price greater than zero.");
                Pause();
                return;
            }

            Console.Write("Quantity: ");

            if (!int.TryParse(
                Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Enter a valid quantity.");
                Pause();
                return;
            }

            Product product = new Product
            {
                ProductId = nextId++,
                ProductName = name,
                Brand = brand,
                Price = price,
                Quantity = quantity
            };

            products.Add(product);

            Console.WriteLine("Product added successfully!");
            Console.WriteLine($"Product ID: {product.ProductId}");

            Pause();
        }

        static void ViewProducts()
        {
            Console.WriteLine("\n=== All Products ===");

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                foreach (Product product in products)
                {
                    product.DisplayProduct();
                }

                Console.WriteLine(
                    $"Total Product Types: {products.Count}");
            }

            Pause();
        }

        static void SearchProduct()
        {
            Console.WriteLine("\n=== Search Product ===");
            Console.Write("Enter Product ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID.");
                Pause();
                return;
            }

            Product? product =
                products.Find(p => p.ProductId == id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                product.DisplayProduct();
            }

            Pause();
        }

        static void UpdateProduct()
        {
            Console.WriteLine("\n=== Update Product ===");
            Console.Write("Enter Product ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID.");
                Pause();
                return;
            }

            Product? product =
                products.Find(p => p.ProductId == id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                Pause();
                return;
            }

            product.DisplayProduct();

            Console.Write("New Product Name: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name is required.");
                Pause();
                return;
            }

            Console.Write("New Brand: ");
            string brand = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(brand))
            {
                Console.WriteLine("Brand is required.");
                Pause();
                return;
            }

            Console.Write("New Price (MMK): ");

            if (!decimal.TryParse(
                Console.ReadLine(), out decimal price) || price <= 0)
            {
                Console.WriteLine("Invalid price.");
                Pause();
                return;
            }

            Console.Write("New Quantity: ");

            if (!int.TryParse(
                Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity.");
                Pause();
                return;
            }

            product.ProductName = name;
            product.Brand = brand;
            product.Price = price;
            product.Quantity = quantity;

            Console.WriteLine("Product updated successfully!");

            Pause();
        }

        static void DeleteProduct()
        {
            Console.WriteLine("\n=== Delete Product ===");
            Console.Write("Enter Product ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID.");
                Pause();
                return;
            }

            Product? product =
                products.Find(p => p.ProductId == id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                product.DisplayProduct();

                Console.Write("Confirm delete? (Y/N): ");
                string confirm = Console.ReadLine() ?? "";

                if (confirm.Equals(
                    "Y", StringComparison.OrdinalIgnoreCase))
                {
                    products.Remove(product);
                    Console.WriteLine(
                        "Product deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Delete cancelled.");
                }
            }

            Pause();
        }

        static void SellProduct()
        {
            Console.WriteLine("\n=== Sell Product ===");
            Console.Write("Enter Product ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID.");
                Pause();
                return;
            }

            Product? product =
                products.Find(p => p.ProductId == id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                Pause();
                return;
            }

            product.DisplayProduct();

            Console.Write("Quantity to sell: ");

            if (!int.TryParse(
                Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Enter a valid quantity.");
                Pause();
                return;
            }

            if (quantity > product.Quantity)
            {
                Console.WriteLine("Not enough stock available.");
                Pause();
                return;
            }

            decimal total = product.Price * quantity;
            product.Quantity -= quantity;

            Console.WriteLine("\n========== SALES RECEIPT ==========");
            Console.WriteLine($"Product: {product.ProductName}");
            Console.WriteLine($"Quantity Sold: {quantity}");
            Console.WriteLine($"Unit Price: {product.Price:N0} MMK");
            Console.WriteLine($"Total: {total:N0} MMK");
            Console.WriteLine($"Remaining Stock: {product.Quantity}");
            Console.WriteLine("===================================");
            Console.WriteLine("Sale completed successfully!");

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
