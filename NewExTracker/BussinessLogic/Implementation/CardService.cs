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
        private ICardNumberParser _cardNumberParser;

        public CardService(ICardRepository cardRepository, ICardNumberParser cardNumberParser)
        {
            _cardRepository = cardRepository;
            _cardNumberParser = cardNumberParser;
        }

        public CardResponse GetCardResponse(string receivedMessage, string ownerPhoneNumber)
        {
            CardResponse cardResponse = new CardResponse();
            var cardsLastDigits = _cardNumberParser.ParseCardNumber(receivedMessage);
            if (cardsLastDigits != 0)
            {
                var cardsByOwnerPhoneNumer = _cardRepository.GetCardResponseByOwnerPhoneNumber(ownerPhoneNumber);
                if (cardsByOwnerPhoneNumer != null)
                {
                    cardResponse = cardsByOwnerPhoneNumer.Where(a => a.CardNumber.ToString().Contains(cardsLastDigits.ToString())).FirstOrDefault();
                    return cardResponse;
                }
            }
            return null;
        }

        public Card GetCard(string receivedMessage, string ownerPhoneNumber)
        {
            Card card = new Card();
            var cardsLastDigits = _cardNumberParser.ParseCardNumber(receivedMessage);
            if (cardsLastDigits != 0)
            {
                var cardsByOwnerPhoneNumer = _cardRepository.GetCardByOwnerPhoneNumber(ownerPhoneNumber);
                if (cardsByOwnerPhoneNumer != null)
                {
                    card = cardsByOwnerPhoneNumer.Where(a => a.CardNumber.ToString().Contains(cardsLastDigits.ToString())).FirstOrDefault();
                }
            }
            return null;
        }

    }
}
