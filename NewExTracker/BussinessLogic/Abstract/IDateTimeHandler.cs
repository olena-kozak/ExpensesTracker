using NewExTracker.BussinessLogic.Abstract;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IDateTimeHandler
    {
        public string GetDateTimeStartWith(string message);

        public string GetDateTime(string message);

    }
}
