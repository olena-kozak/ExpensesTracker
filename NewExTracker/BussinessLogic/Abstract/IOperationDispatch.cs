using ExpensesTracker.Models.DTO;

namespace ExpensesTracker.BussinessLogic
{
    public interface IOperationDispatch
    {
        public MessageResponse Dispatch(string receivedMessage, string ownerPhoneNumber);
    }
}
