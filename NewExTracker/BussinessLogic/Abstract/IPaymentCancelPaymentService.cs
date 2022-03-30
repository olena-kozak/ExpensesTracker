using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IPaymentCancelPaymentService
    {
        public PaymentCancelPaymentMessage HandlePaymentCancelPaymentOperation(string receivedMessage, string ownerPhoneNumber, string operationType);
    }
}
