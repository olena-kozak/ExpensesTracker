﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewExTracker.Models
{
    public class ParseMessageRequest
    {
        public string Message { get; set; }
        public string OwnerPhoneNumber { get; set; }
    }
}