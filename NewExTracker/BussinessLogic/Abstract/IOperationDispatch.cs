using NewExTracker.Models.DTO;

namespace NewExTracker.BussinessLogic
{
    public interface IOperationDispatch
    {
        public object Dispatch(string receivedMessage, string ownerPhoneNumber);
    }
}
