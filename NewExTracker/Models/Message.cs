using System;
using System.Collections.Generic;

namespace NewExTracker.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string MessageType { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public int CardId { get; set; }
        public int PlaceId { get; set; }

        public virtual Card Card { get; set; } = null!;
        public virtual Place Place { get; set; } = null!;
    }
}
