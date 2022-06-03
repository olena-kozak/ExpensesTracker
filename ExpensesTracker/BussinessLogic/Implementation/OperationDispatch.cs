using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.BussinessLogic.Exceptions;
using ExpensesTracker.Models;
using ExpensesTracker.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class OperationDispatch : IOperationDispatch
    {
        private IOperationTypeHandler _operationTypeHandler;
        private IPaymentCancelPaymentService _paymentCancelPaymentService;

        public OperationDispatch(IOperationTypeHandler operationTypeHandler, IPaymentCancelPaymentService paymentCancelPaymentService)
        {
            _operationTypeHandler = operationTypeHandler;
            _paymentCancelPaymentService = paymentCancelPaymentService;
        }

        public MessageResponse Dispatch(string receivedMessage, string ownerPhoneNumber)
        {
            var operationType = _operationTypeHandler.GetOperationType(receivedMessage);
            MessageResponse messageResponse = new MessageResponse();
            messageResponse.MessageType = operationType;

            if (operationType.Equals(OperationType.PAYMENT, StringComparison.OrdinalIgnoreCase)
               || operationType.Equals(OperationType.PAYMENT_CANCEL, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var paymentCancelPaymentMessage = _paymentCancelPaymentService.HandlePaymentCancelPaymentOperation(receivedMessage, ownerPhoneNumber, operationType);
                    if (paymentCancelPaymentMessage != null)
                    {
                        messageResponse.MessageObject = paymentCancelPaymentMessage;
                        return messageResponse;
                    }
                }
                catch (RegexException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    messageResponse.MessageType = ex.ErrorMessage;
                }
                catch (CardNotFoundException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    messageResponse.MessageType = ex.ErrorMessage;
                }
                catch (PlaceNotFoundException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    messageResponse.MessageType = ex.ErrorMessage;
                }

                return messageResponse;
            }
            else if (operationType.Equals(OperationType.REFUSAL, StringComparison.OrdinalIgnoreCase))
            {
                // messageResponse.MessageObject = RefusalOperationHandler(paymentInformation);
                return null;
            }
            else
            {
                return null;
            }
        }

    }
}
