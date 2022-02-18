using System;
using System.Collections.Generic;

namespace NewExTracker.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public bool HasLimitPerMonth { get; set; }
        public int? PersonId { get; set; }
        public int? LimitId { get; set; }

        public virtual Person? Person { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
