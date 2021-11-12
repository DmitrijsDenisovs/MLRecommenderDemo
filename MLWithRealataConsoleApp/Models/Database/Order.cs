using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public string PublicId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CustomerEmail { get; set; }
        public int? CustomerAddressId { get; set; }
        public string ExternalPaymentId { get; set; }
        public DateTimeOffset? PaymentTimestamp { get; set; }
        public decimal ShippingPrice { get; set; }
        public bool Deleted { get; set; }
        public int? ShippingId { get; set; }
        public int EmailDeliveryStatus { get; set; }
        public int PaymentMethod { get; set; }
        public string RefundId { get; set; }

        public virtual Address CustomerAddress { get; set; }
        public virtual ShippingOption Shipping { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
