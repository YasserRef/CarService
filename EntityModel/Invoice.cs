using System;
using System.Collections.Generic;

namespace EntityModel
{   

    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CarService> CarServices { get; set; }
    }

    
}