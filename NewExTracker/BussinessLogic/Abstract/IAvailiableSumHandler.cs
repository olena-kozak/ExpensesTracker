namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface IAvailiableSumHandler
    {
        public string ParseAvailiableSumFromRequest(string message);
        public decimal GetAvailiableSumOnlyDigits(string receivedAvailiableSum);
    }
}
