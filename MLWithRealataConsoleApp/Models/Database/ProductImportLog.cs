using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class ProductImportLog
    {
        public Guid Id { get; set; }
        public int ProductImportJobItemId { get; set; }
        public string ExternalId { get; set; }
        public DateTimeOffset Created { get; set; }
        public int Status { get; set; }

        public virtual ProductImportJobItem ProductImportJobItem { get; set; }
    }
}
