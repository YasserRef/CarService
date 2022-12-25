using System;
using System.Collections.Generic;

namespace EntityModel
{  

    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public List<Invoice> Invoices { get; set; }
    }

    
}