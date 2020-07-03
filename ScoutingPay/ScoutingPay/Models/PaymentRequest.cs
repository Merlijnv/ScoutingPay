using System;
using System.Collections.Generic;

namespace ScoutingPay.Models
{
    public class PaymentRequest
    {
        public DateTime Date = DateTime.Now;
        public Person Person;
        public List<Product> ProductList = new List<Product>();
        public string RequestURL { get; set; }
        public decimal PriceTotal => CalculateTotal();

        public PaymentRequest()
        {
            ProductList = new List<Product>();
        }
        public PaymentRequest(Person person, List<Product> products)
        {
            Person = person;
            ProductList = products;
        }


        private decimal CalculateTotal()
        {
            decimal total = new decimal();
            foreach (Product prod in ProductList)
            {
                total +=  prod.Count * prod.Price;
            }
            return total;
        }
    }
}
