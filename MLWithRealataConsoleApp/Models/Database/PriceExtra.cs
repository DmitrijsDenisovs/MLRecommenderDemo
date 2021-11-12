using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class PriceExtra
    {
        public int Id { get; set; }
        public decimal ToAmount { get; set; }
        public decimal ProfitPercent { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal MinProfitAmount { get; set; }
    }
}
