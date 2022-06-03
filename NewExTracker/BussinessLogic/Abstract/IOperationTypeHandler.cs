namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IOperationTypeHandler  
    {
        public string GetOperationType(string message);
        public string GetOperationSubtype(string message);
    }
}
