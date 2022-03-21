using System;
using System.Collections.Generic;

namespace NewExTracker.Models
{
    public partial class BankingAccount
    {
        public BankingAccount()
        {
            Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public decimal AvailiableSum { get; set; }
        public decimal KredLimits { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
