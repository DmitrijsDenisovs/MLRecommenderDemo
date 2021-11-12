using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class VCategory
    {
        public byte[] Name { get; set; }
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
