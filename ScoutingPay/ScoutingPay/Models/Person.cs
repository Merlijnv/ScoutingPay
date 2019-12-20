using System;
using System.Collections.Generic;

namespace ScoutingPay.Models
{
    public class Person
    {
        public Person(int bonNr, string name, string mail)
        {
            BonNr = bonNr;
            Name = name;
            Mail = mail;
        }


        public Person(int bonNr, string name, string mail, List<PaymentRequest> paymentRequests)
        {
            BonNr = bonNr;
            Name = name;
            Mail = mail;
            PaymentRequests = paymentRequests;
        }

        public int BonNr { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public List<PaymentRequest> PaymentRequests { get; }

    }
}
