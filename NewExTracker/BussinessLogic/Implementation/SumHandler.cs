using NewExTracker.BussinessLogic.Abstract;
using System.Text.RegularExpressions;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class SumHandler : ISumHandler
    {
        public string GetSumAsString(string receivedMessage)
        {
            string sumRegexPattern = @"Suma[:]\s.*\s";
            Regex regex = new Regex(@"Suma[:]\s.+\s\w+[.]");
            Match match = regex.Match(receivedMessage);
            if (match.Success)
            {
                var matchingValue = match.Value;
                int indexStart = matchingValue.IndexOf(":") + 1;
                int indexEnd = matchingValue.IndexOf(".");
                int substringLength = indexEnd - indexStart;
                var sum = (match.Value).Substring(indexStart, substringLength).Trim();
                return sum;
            }

            return null;
        }
    }
}
