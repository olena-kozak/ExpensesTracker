namespace ExpensesTracker.Models
{
    public class PaymentCancelPaymentMessage : BaseMessage
    {
        public string AvailiableSum { get; set; }
        public decimal KredLim { get; set; }
    }
}
