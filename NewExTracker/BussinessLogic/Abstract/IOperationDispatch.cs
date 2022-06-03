using NewExTracker.Models.DTO;

namespace NewExTracker.BussinessLogic
{
    public interface IOperationDispatch
    {
        public MessageResponse Dispatch(string receivedMessage, string ownerPhoneNumber);
    }
}
