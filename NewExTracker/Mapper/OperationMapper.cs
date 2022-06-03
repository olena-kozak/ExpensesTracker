using ExpensesTracker.Models;

namespace ExpensesTracker.Mapper
{
    public static class OperationMapper
    {
        public static PaymentCancelPaymentMessage ToPaymentCancelPaymentMessage(this BaseMessage baseMessage)
        {
            return new PaymentCancelPaymentMessage
            {
                DateTime = baseMessage.DateTime,
                OperationSubtype = baseMessage.OperationSubtype,
                Place = baseMessage.Place,
                Sum = baseMessage.Sum
            };
        }
    }
}
