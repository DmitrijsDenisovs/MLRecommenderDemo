using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class OrderStatusHistory
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int OrderProductId { get; set; }

        public virtual OrderProduct OrderProduct { get; set; }
    }
}
