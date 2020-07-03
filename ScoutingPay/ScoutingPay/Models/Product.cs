using System;
using Newtonsoft.Json;

namespace ScoutingPay.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }


        [JsonConstructor]
        public Product(int id, string productName, decimal price)
        {
            Id = id;
            ProductName = productName;
            Price = price;
        }


        public Product(int id, string productName, decimal price, int count)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            Count = count;
        }
        
        
    }
}
