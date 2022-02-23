namespace NewExTracker.BussinessLogic.Abstract
{
    public interface ICardNumberParser
    {
        public int ParseCardNumber(string receivedMessage);
    }
}
