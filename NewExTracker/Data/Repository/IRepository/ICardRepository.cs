using NewExTracker.Models;
using NewExTracker.Models.DTO;

namespace NewExTracker.Data.Repository.IRepository
{
    public interface ICardRepository
    {
        ICollection<Card> GetCards();

        Card GetCard(int card);

        public List<Card> GetCardByLastDigits(int lastDigits);

        public List<CardResponse> GetCardByOwnerPhoneNumber(string ownerPhoneNumber);

        bool CardExist(string name);


        bool CardExist(int id);


        bool CreateCard(Card card);


        bool UpdateCard(Card card);


        bool DeleteCard(Card card);


        bool Save();
    }
}
