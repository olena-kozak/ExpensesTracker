using NewExTracker.Models;
using NewExTracker.Models.DTO;

namespace NewExTracker.Data.Repository.IRepository
{
    public interface ICardRepository
    {
        public List<Card> GetCardByLastDigits(int lastDigits);

        public List<Card> GetCardByOwnerPhoneNumber(string ownerPhoneNumber);

        bool Save();
    }
}
