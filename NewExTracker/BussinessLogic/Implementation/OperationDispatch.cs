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

        private IOperationTypeHandler _operationTypeHandler;
        private IPaymentCancelPaymentService _paymentCancelPaymentService;

        public OperationDispatch(IOperationTypeHandler operationTypeHandler, IPaymentCancelPaymentService paymentCancelPaymentService)   //DI inject array of dependency
        {
            _operationTypeHandler = operationTypeHandler;
            _paymentCancelPaymentService = paymentCancelPaymentService;
        }

        public object Dispatch(string receivedMessage, string ownerPhoneNumber)
        {
            var operationType = _operationTypeHandler.GetOperationType(receivedMessage);


            if (operationType.Equals(OperationType.PAYMENT, StringComparison.OrdinalIgnoreCase) || operationType.Equals(OperationType.PAYMENT_CANCEL, StringComparison.OrdinalIgnoreCase))
            {
                return _paymentCancelPaymentService.HandlePaymentCancelPaymentOperation(receivedMessage, ownerPhoneNumber, operationType);
            }
            else if (operationType.Equals(OperationType.REFUSAL, StringComparison.OrdinalIgnoreCase))
            {
                // return RefusalOperationHandler(paymentInformation);
                return null;
            }
            else if (operationType.Equals(OperationType.PAYMENT_CANCEL, StringComparison.OrdinalIgnoreCase))
            {
                // return CancelPaymentOperationHandler(paymentInformation);
                return null;
            }
            else
            {
                return null;
            }
        }

    }
}
