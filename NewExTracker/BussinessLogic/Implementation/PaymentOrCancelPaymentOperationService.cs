using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.Models;
using ExpensesTracker.Mapper;
using static ExpensesTracker.BussinessLogic.Implementation.BaseOperationService;
using ExpensesTracker.BussinessLogic.Exceptions;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class PaymentCancelPaymentService : IPaymentCancelPaymentService
    {
        private ICardService _cardService;
        private ISumHandler _sumHandler;
        private IOperationTypeHandler _operationTypeHandler;
        private IAvailiableSumHandler _availiableSumHandler;
        private IBankingAccountService _bankingAccountService;
        private IBaseMessageCreator<PaymentCancelPaymentMessage> _baseMessageCreator;

        public PaymentCancelPaymentService(IOperationTypeHandler operationTypeHandler, ICardService cardService, ISumHandler sumHandler,
                                            IAvailiableSumHandler availiableSumHandler, IBankingAccountService bankingAccountService,
                                            IBaseMessageCreator<PaymentCancelPaymentMessage> baseMessageCreator)                                                                             
        {
            _cardService = cardService;
            _sumHandler = sumHandler;
            _operationTypeHandler = operationTypeHandler;
            _availiableSumHandler = availiableSumHandler;
            _bankingAccountService = bankingAccountService;
            _baseMessageCreator = baseMessageCreator;
        }

        public PaymentCancelPaymentMessage HandlePaymentCancelPaymentOperation(string receivedMessage, string ownerPhoneNumber, string operationType)
        {
            Card card = _cardService.GetCard(receivedMessage, ownerPhoneNumber);
            if (card != null)
            {
                var parsedAvailiableSumFromRequest = _availiableSumHandler.ParseAvailiableSumFromRequest(receivedMessage);
                var sum = _sumHandler.GetSumAsDecimal(receivedMessage);
                //var availiableSum = _bankingAccountService.UpdateAvailiableSum(card.BankingAccount, sum, parsedAvailiableSumFromRequest);
                //if (availiableSum != null)
                //{
                PaymentCancelPaymentMessage paymentOrCancelPaymentMessage = _baseMessageCreator.HandleBaseOperation(receivedMessage);
                paymentOrCancelPaymentMessage.OperationSubtype = _operationTypeHandler.GetOperationSubtype(receivedMessage);
                paymentOrCancelPaymentMessage.CardNumber = card.CardNumber;
                paymentOrCancelPaymentMessage.UserName = card.CardUser.Person.Name;                                                      //TODO: card user can't be null
                paymentOrCancelPaymentMessage.UserSurname = card.CardUser.Person.Surname;
                // paymentOrCancelPaymentMessage.AvailiableSum = availiableSum;
                return paymentOrCancelPaymentMessage;
                //}
            }
            else
            {
                throw new CardNotFoundException("Card not found exception");
            }
        }
    }
}
