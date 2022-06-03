
using NewExTracker.Models;
using NewExTracker.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IMessageParserService
    {
        public MessageResponse ParseMessageInObject(MessageRequest messageRequest);



    }
}
