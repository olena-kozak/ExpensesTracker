using NewExTracker.Models;
using NewExTracker.Models.DTO;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface ICardService
    {
        public Card GetCard(string receivedMessage, string ownerNumber);
    }
}
