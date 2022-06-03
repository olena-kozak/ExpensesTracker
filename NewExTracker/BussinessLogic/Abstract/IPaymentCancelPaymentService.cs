using ExpensesTracker.Models;

namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface IPaymentCancelPaymentService
    {
        public PaymentCancelPaymentMessage HandlePaymentCancelPaymentOperation(string receivedMessage, string ownerPhoneNumber, string operationType);
    }
}
