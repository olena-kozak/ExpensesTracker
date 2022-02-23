using Microsoft.EntityFrameworkCore;
using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;
using NewExTracker.Models.DTO;

namespace NewExTracker.Data.Repository
{
    public class CardRepository : ICardRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public CardRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Card GetCard(int cardId)
        {
            return _dbContext.Cards.Where(x => x.Id == cardId)
                                   .Include(navigationPropertyPath: x => x.BankingAccount)
                                   .FirstOrDefault();
        }

        public List<Card> GetCardByLastDigits(int lastDigits)
        {
            var cards = _dbContext.Cards.Where(a => a.CardNumber.ToString().Contains(lastDigits.ToString())).ToList();
            return cards;
        }

        public List<Card> GetCardByOwnerPhoneNumber(string ownerPhoneNumber)
        {
            return _dbContext.Cards.Where(x => x.CardOwner.Person.PhoneNumber == ownerPhoneNumber)
                                         .Include(x => x.BankingAccount)
                                         .Include(x => x.CardOwner)
                                         .ToList();
        }

        public List<CardResponse> GetCardResponseByOwnerPhoneNumber(string ownerPhoneNumber)
        {
            var entity = _dbContext.Cards
            .Join(_dbContext.Owners,
            card => card.CardOwnerId,
            owner => owner.Id,
            (card, owner) => new
            {
                CardId = card.Id,
                CardNumber = card.CardNumber,
                CardOwnerId = owner.PersonId,
                UserId = card.UserId,
            })
            .Join(_dbContext.Users,
            a => a.UserId,
            user => user.Id,
            (a, user) => new
            {
                CardId = a.CardId,
                CardNumber = a.CardNumber,
                CardOwnerId = a.CardOwnerId,
                UserId = user.PersonId,
            })
            .Join(_dbContext.People,
            a => a.UserId,
            user => user.Id,
            (a, user) => new
            {
                CardId = a.CardId,
                CardNumber = a.CardNumber,
                UserName = user.Name,
                UserSurname = user.Surname,
                CardOwnerId = a.CardOwnerId
            })
            .Join(_dbContext.People,
            a => a.CardOwnerId,
            person => person.Id,
            (a, person) => new
            {
                CardId = a.CardId,
                CardNumber = a.CardNumber,
                CardOwnerName = person.Name,
                CardOwnerSurname = person.Surname,
                CardOwnerPhoneNumber = person.PhoneNumber,
                UserName = a.UserName,
                UserSurname = a.UserSurname,
            })
          .Where(x => x.CardOwnerPhoneNumber == ownerPhoneNumber).ToList();

            List<CardResponse> cardsResponse = entity.Select(
                x => new CardResponse
                {
                    CardId = x.CardId,
                    CardNumber = x.CardNumber,
                    UserName = x.UserName,
                    UserSurname = x.UserSurname
                }).ToList();
            return cardsResponse;

        }



        public ICollection<Card> GetCards()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }


    }
}
