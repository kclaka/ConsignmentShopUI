using System;
using System.Collections.Generic;
using System.Text;

namespace consignmentShopLib
{
    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public bool sold { get; set; }
        public bool PaymentDistributed { get; set; }
        public Vendor Owner { get; set; }

        public string Display {
            get
            {
                return string.Format($"{title} - ${price}");
            }
                
              
        
        }
    }
}
