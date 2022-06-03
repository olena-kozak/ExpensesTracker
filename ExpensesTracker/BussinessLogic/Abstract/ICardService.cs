using ExpensesTracker.Models;
using ExpensesTracker.Models.DTO;

namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface ICardService
    {
        public Card GetCard(string receivedMessage, string ownerNumber);
    }
}
