using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class GoogleFeedProduct
    {
        public int Id { get; set; }
        public string CustomLabel3 { get; set; }
        public DateTimeOffset LastSaleDate { get; set; }

        public virtual Product IdNavigation { get; set; }
    }
}
