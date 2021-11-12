using System;
using System.Collections.Generic;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class Job1
    {
        public Job1()
        {
            JobParameter1s = new HashSet<JobParameter1>();
            State1s = new HashSet<State1>();
        }

        public long Id { get; set; }
        public long? StateId { get; set; }
        public string StateName { get; set; }
        public string InvocationData { get; set; }
        public string Arguments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpireAt { get; set; }

        public virtual ICollection<JobParameter1> JobParameter1s { get; set; }
        public virtual ICollection<State1> State1s { get; set; }
    }
}
