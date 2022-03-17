namespace NewExTracker.BussinessLogic.Abstract
{
    public interface ISumHandler
    {
        public string GetSumAsString(string receivedMessage); 
        public decimal GetSumAsDecimal(string receivedMessage);
    }
}
