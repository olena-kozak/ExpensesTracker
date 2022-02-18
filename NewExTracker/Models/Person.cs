using System;
using System.Collections.Generic;

namespace NewExTracker.Models
{
    public partial class Person
    {
        public Person()
        {
            Owners = new HashSet<Owner>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
