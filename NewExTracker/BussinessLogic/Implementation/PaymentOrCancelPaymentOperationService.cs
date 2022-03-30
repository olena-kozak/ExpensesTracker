using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class PaymentCancelPaymentService : IPaymentCancelPaymentService
    {
        private ICardService _cardService;
        private IPlaceService _placeService;
        private IDateTimeHandler _dateTimeHandler;
        private ISumHandler _sumHandler;
        private IOperationTypeHandler _operationTypeHandler;
        private IAvailiableSumHandler _availiableSumHandler;
        private IBankingAccountService _bankingAccountService;

        public PaymentCancelPaymentService(IDateTimeHandler dateTimeHandler, IOperationTypeHandler operationTypeHandler, IAvailiableSumHandler availiableSumHandler,
            IBankingAccountService bankingAccountService, ICardService cardService, IPlaceService placeService, ISumHandler sumHandler)
        {
            _dateTimeHandler = dateTimeHandler;
            _operationTypeHandler = operationTypeHandler;
            _availiableSumHandler = availiableSumHandler;
            _bankingAccountService = bankingAccountService;
            _cardService = cardService;
            _dateTimeHandler = dateTimeHandler;
            _sumHandler = sumHandler;
            _placeService = placeService;
        }

        public PaymentCancelPaymentMessage HandlePaymentCancelPaymentOperation(string receivedMessage, string ownerPhoneNumber, string operationType)
        {
            PaymentCancelPaymentMessage paymentOrCancelPaymentMessage = new PaymentCancelPaymentMessage();

            Card card = _cardService.GetCard(receivedMessage, ownerPhoneNumber);
            if (card != null)                                                                               // TODO: if card is null
            {
                paymentOrCancelPaymentMessage.CardNumber = card.CardNumber;
                paymentOrCancelPaymentMessage.UserName = card.CardUser.Person.Name;                                        //TODO: card user can't be null
                paymentOrCancelPaymentMessage.UserSurname = card.CardUser.Person.Surname;
                paymentOrCancelPaymentMessage.Place = _placeService.GetPlaceByOtpSmartName(receivedMessage);
                if (operationType.Equals(OperationType.PAYMENT_CANCEL, StringComparison.OrdinalIgnoreCase))
                {
                    paymentOrCancelPaymentMessage.MessageType = OperationType.PAYMENT_CANCEL;
                }
                else
                {
                    paymentOrCancelPaymentMessage.MessageType = OperationType.PAYMENT;
                }
                paymentOrCancelPaymentMessage.OperationSubtype = _operationTypeHandler.GetOperationSubtype(receivedMessage);
                paymentOrCancelPaymentMessage.Sum = _sumHandler.GetSumAsString(receivedMessage);
                decimal sum = _sumHandler.GetSumAsDecimal(receivedMessage);
                paymentOrCancelPaymentMessage.DateTime = _dateTimeHandler.GetDateTime(receivedMessage);
                string parsedAvailiableSumFromRequest = _availiableSumHandler.ParseAvailiableSumFromRequest(receivedMessage);
                paymentOrCancelPaymentMessage.AvailiableSum = _bankingAccountService.UpdateAvailiableSum(card.BankingAccount, sum, parsedAvailiableSumFromRequest);   //TODO: bankingAccount can't be null

                return paymentOrCancelPaymentMessage;
            }
            else
            {
                paymentOrCancelPaymentMessage.MessageType = "Card was not found";
                return paymentOrCancelPaymentMessage;
            }
        }
    }
}
