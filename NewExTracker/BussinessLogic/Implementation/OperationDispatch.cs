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
        private IPlaceService _placeService;
        private IDateTimeHandler _dateTimeHandler;
        private ISumHandler _sumHandler;
        private IBankingAccountService _bankingAccountService;
        private IAvailiableSumHandler _availiableSumHandler;

        public OperationDispatch(ICardService cardService, IDateTimeHandler dateTimeHandler, ISumHandler sumHandler, IPlaceService placeService,
            IBankingAccountService bankingAccountService, IAvailiableSumHandler availiableSumHandler)
        {
            _cardService = cardService;
            _dateTimeHandler = dateTimeHandler;
            _sumHandler = sumHandler;
            _placeService = placeService;
            _bankingAccountService = bankingAccountService;
            _availiableSumHandler = availiableSumHandler;

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
            Card card = _cardService.GetCard(message, ownerPhoneNumber);
            messageResponse.CardNumber = card.CardNumber;
            messageResponse.UserName = card.CardUser.Person.Name;            //TODO: card user can't be null
            messageResponse.UserSurname = card.CardUser.Person.Surname;
            messageResponse.Place = _placeService.GetPlaceByOtpSmartName(message);

            BankingAccount bankingAccount = card.BankingAccount;               //TODO: remove cast, banking account id can't be null

            //get availiable sum from message, compare with availiable sum on bankingAccount
            string receivedAvailiableSum = _availiableSumHandler.GetAvailiableSum(message);
            if (receivedAvailiableSum != null)
            {
                bool isAvailiableSumSame = _bankingAccountService.CheckAlailibleSum(bankingAccount, receivedAvailiableSum);
                if (isAvailiableSumSame)
                {
                    messageResponse.AvailiableSum = receivedAvailiableSum;
                }
            }

            return messageResponse;
        }
        public static void RefusalOperationHandler(string message)
        {

        }
    }


}
