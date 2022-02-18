using System;
using System.Collections.Generic;

namespace NewExTracker.Models
{
    public partial class Place
    {
        public Place()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string OtpsmartName { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
