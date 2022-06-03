using ExpensesTracker.Models;
using ExpensesTracker.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface IMessageParserService
    {
        public MessageResponse ParseMessageInObject(MessageRequest messageRequest);



    }
}
