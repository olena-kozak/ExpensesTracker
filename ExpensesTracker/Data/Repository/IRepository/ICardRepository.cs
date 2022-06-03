using ExpensesTracker.Models;
using ExpensesTracker.Models.DTO;

namespace ExpensesTracker.Data.Repository.IRepository
{
    public interface ICardRepository
    {
        public List<Card> GetCardByLastDigits(int lastDigits);

        public List<Card> GetCardByOwnerPhoneNumber(string ownerPhoneNumber);

        bool Save();
    }
}
