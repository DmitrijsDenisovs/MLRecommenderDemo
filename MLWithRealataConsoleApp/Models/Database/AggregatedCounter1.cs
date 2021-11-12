using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class AggregatedCounter1
    {
        public string Key { get; set; }
        public long Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
