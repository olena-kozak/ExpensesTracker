using NewExTracker.Models;
using NewExTracker.Models.DTO;

namespace NewExTracker.Data.Repository.IRepository
{
    public interface ICardRepository
    {
        ICollection<Card> GetCards();

        public List<Card> GetCardByLastDigits(int lastDigits);

        public List<CardResponse> GetCardResponseByOwnerPhoneNumber(string ownerPhoneNumber);

        public List<Card> GetCardByOwnerPhoneNumber(string ownerPhoneNumber);

        bool Save();
    }
}
