using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class OrderProduct
    {
        public OrderProduct()
        {
            OrderStatusHistories = new HashSet<OrderStatusHistory>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int OrderId { get; set; }
        public string ExternalOrderId { get; set; }
        public string MerchantName { get; set; }
        public string MerchantOrderId { get; set; }
        public string Note { get; set; }
        public string OrderFailedErrorMessage { get; set; }
        public int RetailerAccountId { get; set; }
        public int Status { get; set; }
        public string TrackingCarrier { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingUrl { get; set; }
        public bool Deleted { get; set; }
        public string ExternalId { get; set; }
        public string Title { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual RetailerAccount RetailerAccount { get; set; }
        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; }
    }
}
