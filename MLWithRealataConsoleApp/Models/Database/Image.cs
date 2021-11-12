using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string OriginalUrl { get; set; }
        public string Url { get; set; }
        public string Thumb { get; set; }

        public virtual Product Product { get; set; }
    }
}
