using System;
namespace ScoutingPay.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }


        public Product(int id, string productName, double price)
        {
            Id = id;
            ProductName = productName;
            Price = price;
        }


        public Product(int id, string productName, double price, int count)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            Count = count;
        }
    }
}
