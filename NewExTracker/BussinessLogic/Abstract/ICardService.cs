using NewExTracker.Models;
using NewExTracker.Models.DTO;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface ICardService
    {
        public CardResponse GetCardResponse(string receivedMessage, string phoneNumber);
    }
}
