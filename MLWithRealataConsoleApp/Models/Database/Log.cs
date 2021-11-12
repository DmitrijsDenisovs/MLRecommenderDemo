using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Server { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string RequestBody { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseBody { get; set; }
        public int ProcessingTimeMs { get; set; }
    }
}
