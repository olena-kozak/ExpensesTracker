using System;
using System.Collections.Generic;

namespace NewExTracker.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }

        public virtual Person? Person { get; set; }
    }
}
