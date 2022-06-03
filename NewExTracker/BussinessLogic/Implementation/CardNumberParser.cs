using ExpensesTracker.BussinessLogic.Abstract;
using System.Text.RegularExpressions;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class CardNumberParser : ICardNumberParser
    {
        public int ParseCardNumber(string receivedMessage)
        {
            int cardNumber = 0;
            Regex regex = new Regex(@"(\*.*\.)");
            Match matchCardNumber = regex.Match(receivedMessage);
            if (matchCardNumber.Success)
            {
                var matchingValue = matchCardNumber.Groups[0].Value;
                var indexToStart = matchingValue.IndexOf("*") + 1;
                var substring = matchingValue.Substring(indexToStart, 4).Trim();
                cardNumber = int.Parse(substring);
                return cardNumber;
            }
            return cardNumber;
        }
    }
}
