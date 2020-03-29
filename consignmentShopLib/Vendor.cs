using System;
using System.Collections.Generic;
using System.Text;

namespace consignmentShopLib
{
    public class Vendor
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public double commission { get; set; }
        public decimal PaymentDue { get; set; }


        public Vendor()
        {

        }

        public string Display {
            get
            {
                return string.Format($"{firstName} {lastName} ${PaymentDue}");
            } 
        
        }
    }
}
