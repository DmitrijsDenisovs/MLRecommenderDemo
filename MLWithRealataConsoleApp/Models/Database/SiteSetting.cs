using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class SiteSetting
    {
        public Guid Id { get; set; }
        public string ShippingContent { get; set; }
        public string EasyncAuthKey { get; set; }
        public string FeedBlackList { get; set; }
    }
}
