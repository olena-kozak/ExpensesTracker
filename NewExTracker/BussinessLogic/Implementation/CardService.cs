using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;
using NewExTracker.Models.DTO;
using System.Text.RegularExpressions;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public CardResponse GetCard(string receivedMessage, string ownerPhoneNumber)
        {
            CardResponse cardResponse = new CardResponse();
            var cardsLastDigits = ParseCardNumber(receivedMessage);
            if (cardsLastDigits != 0)
            {
                var cardsByOwnerPhoneNumer = _cardRepository.GetCardByOwnerPhoneNumber(ownerPhoneNumber);
                if (cardsByOwnerPhoneNumer != null)
                {
                    cardResponse = cardsByOwnerPhoneNumer.Where(a => a.CardNumber.ToString().Contains(cardsLastDigits.ToString())).FirstOrDefault();
                    return cardResponse;
                }
            }
            return null;
        }

        private static int ParseCardNumber(string receivedMessage)
        {
            //Regex regex = new Regex(@"Kartka\s[*].*[.]");
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
