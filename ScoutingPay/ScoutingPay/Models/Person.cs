﻿using System;
using System.Collections.Generic;

namespace ScoutingPay.Models
{
    public class Person
    {
        public Person(int bonNr, string name, string mail,byte active)
        {
            BonNr = bonNr;
            Name = name;
            Mail = mail;
            Active = active;
        }


        public Person(int bonNr, string name, string mail,byte active, List<PaymentRequest> paymentRequests)
        {
            BonNr = bonNr;
            Name = name;
            Mail = mail;
            Active = active;
            PaymentRequests = paymentRequests;
        }

        public int BonNr { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public Byte Active { get; set; }
        public List<PaymentRequest> PaymentRequests { get; }

    }
}
