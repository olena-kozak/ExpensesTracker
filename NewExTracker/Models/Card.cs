using System;
using System.Collections.Generic;

namespace NewExTracker.Models
{
    public partial class Card
    {
        public Card()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public long CardNumber { get; set; }
        public int? BankingAccountId { get; set; }
        public int CardOwnerId { get; set; }
        public int UserId { get; set; }

        public virtual BankingAccount? BankingAccount { get; set; }
        public virtual Owner? CardOwner { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
