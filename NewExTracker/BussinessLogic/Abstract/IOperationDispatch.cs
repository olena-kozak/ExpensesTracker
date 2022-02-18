namespace NewExTracker.BussinessLogic
{
    public interface IOperationDispatch
    {
        public void Dispatch(string receivedMessage, string ownerPhoneNumber);
    }
}
