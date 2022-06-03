using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.Models;

namespace ExpensesTracker.BussinessLogic.Implementation
{
    public class RefusalOperationService
    {
        private IDateTimeHandler _dateTimeHandler { get; set; }
        private IOperationTypeHandler _operationTypeHandler { get; set; }



        public RefusalOperationService()
        {

        }
        /*
        public RefusalMessage RefusalOperationHandler()
        {

            RefusalMessage refusalMessage = new RefusalMessage();
            refusalMessage.MessageType = OperationType.REFUSAL;
            refusalMessage.DateTime = _dateTimeHandler.GetDateTime(operationInformation.Message);
            refusalMessage.OperationSubtype = _operationTypeHandler.GetOperationSubtype(operationInformation.Message);

            return refusalMessage;
        }*/
    }
}
