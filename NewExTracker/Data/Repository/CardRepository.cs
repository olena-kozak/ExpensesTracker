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

        public bool CardExist(string name)
        {
            throw new NotImplementedException();
        }

        public bool CardExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateCard(Card card)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCard(Card card)
        {
            throw new NotImplementedException();
        }

        public Card GetCard(int card)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetCardByLastDigits(int lastDigits)
        {
            var cards = _dbContext.Cards.Where(a => a.CardNumber.ToString().Contains(lastDigits.ToString())).ToList();
            return cards;
        }

        public List<CardResponse> GetCardByOwnerPhoneNumber(string ownerPhoneNumber)
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

        public bool UpdateCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
