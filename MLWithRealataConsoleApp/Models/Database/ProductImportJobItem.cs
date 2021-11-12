using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class ProductImportJobItem
    {
        public ProductImportJobItem()
        {
            ProductImportLogs = new HashSet<ProductImportLog>();
        }

        public int Id { get; set; }
        public int ProductImportJobId { get; set; }
        public string ProductIds { get; set; }
        public int State { get; set; }
        public int Result { get; set; }
        public DateTimeOffset? RequestSent { get; set; }
        public string RequestId { get; set; }
        public DateTimeOffset? DataReceived { get; set; }
        public string Data { get; set; }
        public string ErrorMessage { get; set; }
        public int ProductsReceived { get; set; }

        public virtual ProductImportJob ProductImportJob { get; set; }
        public virtual ICollection<ProductImportLog> ProductImportLogs { get; set; }
    }
}
