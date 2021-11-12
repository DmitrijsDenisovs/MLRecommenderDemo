using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class ProductBlackList
    {
        public int Id { get; set; }
        public string ExternalProductId { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
