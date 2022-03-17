using NewExTracker.BussinessLogic.Abstract;
using System.Text.RegularExpressions;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class AvailiableSumHandler : IAvailiableSumHandler
    {
        public string ParseAvailiableSumFromRequest(string message)
        {
            Regex regex = new Regex(@"Dostupno[:]\s\d*\.\d*\s\w+\s");
            Match match = regex.Match(message);
            if (match.Success)
            {
                var value = match.Value;
                int indexStart = value.IndexOf(":") + 1;
                int length = (value.Length - 1) - indexStart;
                var availiableSum = value.Substring(indexStart, length).Trim();
                return availiableSum;
            }

            return null;
        }

        public decimal GetAvailiableSumOnlyDigits(string receivedAvailiableSum)
        {
            decimal availiableSum = 0;
            Regex regex = new Regex(@"\d*\.\d*\s");
            Match match = regex.Match(receivedAvailiableSum);
            if (match.Success)
            {
                string matchValue = match.Value.TrimEnd();
                Decimal.TryParse(matchValue, out availiableSum);
            }
            return availiableSum;
        }
    }
}
