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
    public class OperationDispatch : IOperationDispatch
    {
        private ICardService _cardService;
        private IDateTimeHandler _dateTimeHandler;
        private ISumHandler _sumHandler;

        public OperationDispatch(ICardService cardHandler, IDateTimeHandler dateTimeHandler, ISumHandler sumHandler)
        {
            _cardService = cardHandler;
            _dateTimeHandler = dateTimeHandler;
            _sumHandler = sumHandler;

        }

        public void Dispatch(string receivedMessage, string ownerPhoneNumber)
        {
            var operationType = GetOperationType(receivedMessage);

            if (operationType.Equals(OperationType.PAYMENT, StringComparison.OrdinalIgnoreCase))
            {
                PaymentOperationHandler(receivedMessage, _dateTimeHandler.GetDateTimeStartWith(receivedMessage), ownerPhoneNumber);
            }
            else if (operationType.Equals(OperationType.REFUSAL, StringComparison.OrdinalIgnoreCase))
            {
                RefusalOperationHandler(receivedMessage);
            }
        }


        private string GetOperationType(string message)
        {
            var dateTimeValue = _dateTimeHandler.GetDateTimeStartWith(message);

            if (dateTimeValue != null)
            {
                return "Payment";
            }

            if (message.Contains("Vidmova:"))
            {
                return "Refusal";
            }
            return null;
        }


        public MessageResponse PaymentOperationHandler(string message, string dateTime, string ownerPhoneNumber)
        {
            MessageResponse messageResponse = new MessageResponse();
            messageResponse.DateTime = dateTime;
            messageResponse.MessageType = "Payment";
            messageResponse.Sum = _sumHandler.GetSumAsString(message);
            CardResponse cardResponse = _cardService.GetCard(message, ownerPhoneNumber);
            messageResponse.CardNumber = cardResponse.CardNumber;
            messageResponse.UserName = cardResponse.UserName;
            messageResponse.UserSurname = cardResponse.UserSurname;


            return messageResponse;
        }
        public static void RefusalOperationHandler(string message)
        {

        }
    }


}
