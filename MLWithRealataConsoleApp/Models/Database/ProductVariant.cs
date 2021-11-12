using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Variants { get; set; }

        public virtual Product Product { get; set; }
    }
}
