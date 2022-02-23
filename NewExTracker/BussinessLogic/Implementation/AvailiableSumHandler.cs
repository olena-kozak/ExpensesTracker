using NewExTracker.BussinessLogic.Abstract;
using System.Text.RegularExpressions;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class AvailiableSumHandler : IAvailiableSumHandler
    {
        public string GetAvailiableSum(string message)
        {
            Regex regex = new Regex(@"Dostupno[:]\s.+\s\w+");
            Match match = regex.Match(message);
            if (match.Success)
            {
                var value = match.Value;
                int indexStart = value.IndexOf(":");
                int length = (value.Length - 1) - indexStart;
                var availiableSum = value.Substring(indexStart, length).Trim();
                return availiableSum;
            }

            return null;
        }
    }
}
