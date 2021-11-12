using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class ShippingOption
    {
        public ShippingOption()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool FastDelivery { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
