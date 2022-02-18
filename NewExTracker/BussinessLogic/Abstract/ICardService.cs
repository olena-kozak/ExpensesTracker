using NewExTracker.Models;
using NewExTracker.Models.DTO;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface ICardService
    {
        public CardResponse GetCard(string receivedMessage, string phoneNumber);
    }
}
