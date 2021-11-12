using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class RetailerAccount
    {
        public RetailerAccount()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int CardExpirationMonth { get; set; }
        public int CardExpirationYear { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityCode { get; set; }
        public string NameOnCard { get; set; }
        public bool UseGift { get; set; }
        public bool Fbe { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
