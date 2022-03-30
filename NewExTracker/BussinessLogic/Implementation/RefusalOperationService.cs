using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class RefusalOperationService
    {
        private IDateTimeHandler _dateTimeHandler { get; set; }
        private IOperationTypeHandler _operationTypeHandler { get; set; }



        public RefusalOperationService()
        {

        }
        public RefusalMessage RefusalOperationHandler(OperationInformation operationInformation)
        {
            RefusalMessage refusalMessage = new RefusalMessage();
            refusalMessage.MessageType = OperationType.REFUSAL;
            refusalMessage.DateTime = _dateTimeHandler.GetDateTime(operationInformation.Message);
            refusalMessage.OperationSubtype = _operationTypeHandler.GetOperationSubtype(operationInformation.Message);

            return refusalMessage;
        }
    }
}
