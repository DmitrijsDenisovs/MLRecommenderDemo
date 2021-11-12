using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class ProductImportJob
    {
        public ProductImportJob()
        {
            ProductImportJobItems = new HashSet<ProductImportJobItem>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Completed { get; set; }
        public int ProductsImported { get; set; }
        public bool CheckGtin { get; set; }

        public virtual ICollection<ProductImportJobItem> ProductImportJobItems { get; set; }
    }
}
