using System;
using System.Collections.Generic;

namespace ScoutingPay.Models
{
    public class PaymentRequest
    {
        public DateTime Date = DateTime.Now;
        public Person Person;
        public int Fris { get; set; } = 0;
        public int Bier { get; set; } = 0;
        public int Chips { get; set; } = 0;
        public int Tosti { get; set; } = 0;
        public List<Product> Products = new List<Product>();
        public string RequestURL { get; set; }
        public double PriceTotal { get { return calculateTotal(); } }

        public PaymentRequest(Person person, List<Product> products)
        {
            Person = person;
            Products = products;
        }


        private double calculateTotal()
        {
            double total = new double();
            foreach (Product prod in Products)
            {
                total +=  prod.Count * prod.Price;
            }
            return total;
        }
    }
}
