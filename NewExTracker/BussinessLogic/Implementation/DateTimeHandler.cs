using ExpensesTracker.BussinessLogic.Abstract;
using System.Text.RegularExpressions;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class DateTimeHandler : IDateTimeHandler
    {
        public string GetDateTimeStartWith(string message)
        {
            Match match = Regex.Match(message, @"^\d\d[/]\d\d\s\d\d[:]\d\d");
            if (match.Success)
            {
                string dateTime = match.Value;
                return match.Value;
            }
            else
            {
                return null;
            }
        }
        public string GetDateTime(string message)
        {
            Match match = Regex.Match(message, @"\d\d[/]\d\d\s\d\d[:]\d\d");
            if (match.Success)
            {
                string dateTime = match.Value;
                return match.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
