using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class SitePageBlock
    {
        public int Id { get; set; }
        public string BlockKey { get; set; }
        public string Title { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Content { get; set; }
    }
}
