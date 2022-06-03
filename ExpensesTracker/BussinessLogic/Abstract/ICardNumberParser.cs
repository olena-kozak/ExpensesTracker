namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface ICardNumberParser
    {
        public int ParseCardNumber(string receivedMessage);
    }
}
