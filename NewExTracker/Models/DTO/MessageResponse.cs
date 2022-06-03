using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewExTracker.Models.DTO
{
    public class MessageResponse
    {
        private string _messageType;
        public string MessageType
        {
            get
            { return _messageType; }
            set
            {
                if (value.Equals(OperationType.PAYMENT, StringComparison.OrdinalIgnoreCase))
                { _messageType = OperationType.PAYMENT; }
                else if (value.Equals(OperationType.PAYMENT_CANCEL, StringComparison.OrdinalIgnoreCase))
                {
                    _messageType = OperationType.PAYMENT_CANCEL;
                }
                else if (value.Equals(OperationType.REFUSAL, StringComparison.OrdinalIgnoreCase))
                {
                    _messageType = OperationType.REFUSAL; ;
                }
                else if (value.Equals(OperationType.CARD_NOT_FOUND, StringComparison.OrdinalIgnoreCase))
                {
                    _messageType = "Card was not found";
                }
                else
                {
                    _messageType = "Unknown operation type";
                }
            }
        }

        public object MessageObject { get; set; }
    }
}
