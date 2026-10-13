
using System;

namespace ComputerShopManagementSystem
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string Brand { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public void DisplayProduct()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine($"Product ID   : {ProductId}");
            Console.WriteLine($"Product Name : {ProductName}");
            Console.WriteLine($"Brand        : {Brand}");
            Console.WriteLine($"Price        : {Price:N0} MMK");
            Console.WriteLine($"Quantity     : {Quantity}");
            Console.WriteLine("==========================================");
        }
    }
}
