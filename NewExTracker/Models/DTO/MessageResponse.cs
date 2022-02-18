using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewExTracker.Models.DTO
{
    public class MessageResponse
    {
        public string MessageType { get; set; }
        public string DateTime { get; set; }
        public long CardNumber { get; set; }

        public string Sum { get; set; }
        public string Place { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
