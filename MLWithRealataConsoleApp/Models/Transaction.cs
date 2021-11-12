using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLWithRealataConsoleApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public List<int> ProductIds { get; set; }
    }
}