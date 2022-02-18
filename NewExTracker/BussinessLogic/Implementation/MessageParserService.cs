using NewExTracker.BussinessLogic;
using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Models;
using NewExTracker.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class MessageParserService : IMessageParserService
    {
        private IOperationDispatch _operationDispatch;

        public MessageParserService(IOperationDispatch operationDispatch)
        {
            _operationDispatch = operationDispatch;
        }
        public MessageResponse ParseMessageInObject(ParseMessageRequest messageRequest)
        {
            string message = GetStringFromMessageRequest(messageRequest);
            string ownerPhoneNumber = GetOwnerPhoneNumber(messageRequest);

            _operationDispatch.Dispatch(message, ownerPhoneNumber);
            return null;
        }

        private string GetOwnerPhoneNumber(ParseMessageRequest requestMessage)
        {
            return requestMessage.OwnerPhoneNumber.Trim();
        }

        private string GetStringFromMessageRequest(ParseMessageRequest requestMessage)
        {
            return requestMessage.Message;
        }
    }
}
