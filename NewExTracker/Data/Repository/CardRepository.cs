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

        public List<Card> GetCardByLastDigits(int lastDigits)
        {
            var cards = _dbContext.Cards.Where(a => a.CardNumber.ToString().Contains(lastDigits.ToString())).ToList();
            return cards;
        }

        public List<Card> GetCardByOwnerPhoneNumber(string ownerPhoneNumber)
        {
            return _dbContext.Cards.Where(x => x.CardOwner.Person.PhoneNumber == ownerPhoneNumber)          //TODO: PERSON MAY BE NULL HERE
                                         .Include(x => x.BankingAccount)
                                         .Include(x => x.CardOwner)
                                         .ThenInclude(x => x.Person)
                                         .Include(x => x.CardUser)
                                         .ThenInclude(x => x.Person)
                                         .ToList();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }


    }
}
