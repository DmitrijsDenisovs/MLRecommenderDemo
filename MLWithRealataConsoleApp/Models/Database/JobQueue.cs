using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class JobQueue
    {
        public int Id { get; set; }
        public long JobId { get; set; }
        public string Queue { get; set; }
        public DateTime? FetchedAt { get; set; }
    }
}
