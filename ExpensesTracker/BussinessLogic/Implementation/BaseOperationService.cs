using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.Models;
using ExpensesTracker.Mapper;
using System.Text.RegularExpressions;
using ExpensesTracker.BussinessLogic.Exceptions;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class BaseOperationService : IBaseOperationService
    {
        private IPlaceService _placeService;
        private IDateTimeHandler _dateTimeHandler;
        private ISumHandler _sumHandler;
        private IOperationTypeHandler _operationTypeHandler;
        public BaseOperationService(IPlaceService placeService, IDateTimeHandler dateTimeHandler, ISumHandler sumHandler, IOperationTypeHandler operationTypeHandler)
        {
            _dateTimeHandler = dateTimeHandler;
            _operationTypeHandler = operationTypeHandler;
            _sumHandler = sumHandler;
            _placeService = placeService;
        }
        public BaseMessage HandleBaseOperation(string receivedMessage, string operationType)
        {
            BaseMessage baseMessage = new BaseMessage();
            baseMessage.Place = _placeService.GetPlaceByOtpSmartName(receivedMessage, operationType);
            baseMessage.OperationSubtype = _operationTypeHandler.GetOperationSubtype(receivedMessage);
            baseMessage.Sum = _sumHandler.GetSumAsString(receivedMessage);
            baseMessage.DateTime = _dateTimeHandler.GetDateTime(receivedMessage);
            return baseMessage;
        }
    }
    public interface IBaseMessageCreator<T> where T : BaseMessage
    {
        public T HandleBaseOperation(string receivedMessage);
    }

    public class PaymentMessageCreator : IBaseMessageCreator<PaymentCancelPaymentMessage>
    {
        private IBaseOperationService _baseOperationService;
        public PaymentMessageCreator(IBaseOperationService baseOperationService)
        {
            _baseOperationService = baseOperationService;
        }
        public PaymentCancelPaymentMessage HandleBaseOperation(string receivedMessage)
        {
            BaseMessage baseMessage = _baseOperationService.HandleBaseOperation(receivedMessage, OperationType.PAYMENT);
            return baseMessage.ToPaymentCancelPaymentMessage();
        }
    }

    public class RefusalMessageCreator : IBaseMessageCreator<RefusalMessage>
    {
        private IBaseOperationService _baseOperationService;
        public RefusalMessageCreator(IBaseOperationService baseOperationService)
        {
            _baseOperationService = baseOperationService;
        }
        public RefusalMessage HandleBaseOperation(string receivedMessage)
        {
            BaseMessage baseMessage = _baseOperationService.HandleBaseOperation(receivedMessage, OperationType.REFUSAL);
            return new RefusalMessage
            {
                DateTime = baseMessage.DateTime,
                OperationSubtype = baseMessage.OperationSubtype,
                Place = baseMessage.Place,
                Sum = baseMessage.Sum
            };
        }
    }
}
