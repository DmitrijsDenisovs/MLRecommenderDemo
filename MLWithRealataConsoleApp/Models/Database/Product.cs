using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class Product
    {
        public Product()
        {
            Images = new HashSet<Image>();
            OrderProducts = new HashSet<OrderProduct>();
            ProductPriceHistories = new HashSet<ProductPriceHistory>();
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceMarkup { get; set; }
        public decimal SalePrice { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Ean { get; set; }
        public string Upc { get; set; }
        public string Mpn { get; set; }
        public int? CategoryId { get; set; }
        public bool Available { get; set; }
        public DateTimeOffset? LastAvailableTimestamp { get; set; }
        public int AvailabilityChangedBy { get; set; }
        public string Features { get; set; }
        public int Stock { get; set; }
        public int? ExternalIdComputed { get; set; }

        public virtual Category Category { get; set; }
        public virtual GoogleFeedProduct GoogleFeedProduct { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ProductPriceHistory> ProductPriceHistories { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
