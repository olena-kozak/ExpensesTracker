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

        public Card GetCard(string receivedMessage, string ownerPhoneNumber)
        {
            var cardsLastDigits = _cardNumberParser.ParseCardNumber(receivedMessage);
            if (cardsLastDigits != 0)
            {
                var cardsByOwnerPhoneNumer = _cardRepository.GetCardByOwnerPhoneNumber(ownerPhoneNumber);
                if (cardsByOwnerPhoneNumer != null)
                {
                    return cardsByOwnerPhoneNumer.Where(a => a.CardNumber.ToString().Contains(cardsLastDigits.ToString())).FirstOrDefault();
                }
            }
            return null;
        }


    }
}
