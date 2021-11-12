using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class ProductPriceHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}
