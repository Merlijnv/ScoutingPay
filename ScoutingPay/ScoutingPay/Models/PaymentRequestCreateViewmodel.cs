using System.Collections.Generic;
using System.Dynamic;

namespace ScoutingPay.Models
{
    public class PaymentRequestCreateViewmodel
    {
        
        public List<Product> ProductOverview { get; set; }
        public PaymentRequest Request { get; set; }
        public Person PersonForRequest { get; set; }
        public int PersonIndex { get; set; } = 0;

        public PaymentRequestCreateViewmodel()
        {
            ProductOverview = new List<Product>();
            Request = new PaymentRequest();
        }
        
        public PaymentRequestCreateViewmodel(int personIndex, List<Product> products, List<Person> persons)
        {
            ProductOverview = products;
            PersonIndex = personIndex;
            PersonForRequest = persons[PersonIndex];
        }

        public void SetModel(PaymentRequest request)
        {
            Request = request;
        }

        public void NextIndex()
        {
            PersonIndex += 1;
        }
        
        
    
    }
}