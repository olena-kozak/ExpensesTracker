using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class OperationTypeHandler : IOperationTypeHandler
    {
        private IDateTimeHandler _dateTimeHandler;
        public OperationTypeHandler(IDateTimeHandler dateTimeHandler)
        {
            _dateTimeHandler = dateTimeHandler;
        }

        public string GetOperationType(string message)
        {
            var dateTimeValue = _dateTimeHandler.GetDateTimeStartWith(message);

            if (dateTimeValue != null)
            {
                return OperationType.PAYMENT;
            }
            else if (message.Contains("Vidmova:"))
            {
                return OperationType.REFUSAL;
            }
            else if (message.Contains("VIDMINA"))
            {
                return OperationType.PAYMENT_CANCEL;
            }

            return null;
        }

        public string GetOperationSubtype(string message)
        {
            if (message.Contains("Splata za tovar/poslugu."))
            {
                return OperationType.PRODUCT_PAYMENT;
            }
            else if (message.Contains("C2C perekaz koshtiv"))
            {
                return OperationType.MONEY_TRANSFERRING;
            }
            else if (message.Contains("Otrymannya gotivky"))
            {
                return OperationType.CASH_WITHDROWN;
            }
            if (message.Contains("VIDMINA"))
            {
                return OperationType.PRODUCT_PAYMENT;
            }
            else return "";
        }
    }
}
