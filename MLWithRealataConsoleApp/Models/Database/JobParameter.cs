﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class JobParameter
    {
        public long JobId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Job Job { get; set; }
    }
}
