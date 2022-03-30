using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewExTracker.Models.DTO
{
    public class MessageResponse
    {
        public string MessageType { get; set; }

        public object MessageObject { get; set; }
    }
}
