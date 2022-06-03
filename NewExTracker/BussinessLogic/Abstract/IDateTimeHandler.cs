using ExpensesTracker.BussinessLogic.Abstract;

namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface IDateTimeHandler
    {
        public string GetDateTimeStartWith(string message);

        public string GetDateTime(string message);

    }
}
