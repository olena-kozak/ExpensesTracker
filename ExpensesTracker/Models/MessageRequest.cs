using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.Models
{
    public class MessageRequest
    {
        public string Message { get; set; }
        public string OwnerPhoneNumber { get; set; }
    }
}
