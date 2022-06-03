using ExpensesTracker.BussinessLogic;
using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.Models;
using ExpensesTracker.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class MessageParserService : IMessageParserService
    {
        private IOperationDispatch _operationDispatch;

        public MessageParserService(IOperationDispatch operationDispatch)
        {
            _operationDispatch = operationDispatch;
        }

        public MessageResponse ParseMessageInObject(MessageRequest messageRequest)
        {
            string message = GetStringFromMessageRequest(messageRequest);
            string ownerPhoneNumber = GetOwnerPhoneNumber(messageRequest);
            return _operationDispatch.Dispatch(message, ownerPhoneNumber);
        }

        private string GetOwnerPhoneNumber(MessageRequest requestMessage)
        {
            return requestMessage.OwnerPhoneNumber.Trim();
        }

        private string GetStringFromMessageRequest(MessageRequest requestMessage)
        {
            return requestMessage.Message;
        }
    }
}
