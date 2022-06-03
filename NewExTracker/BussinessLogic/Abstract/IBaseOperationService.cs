using ExpensesTracker.Models;

namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface IBaseOperationService
    {
        public BaseMessage HandleBaseOperation(string receivedMessages, string operationType);
    }
}
