namespace ExpensesTracker.BussinessLogic.Exceptions
{
    public class PlaceNotFoundException : Exception
    {
        private readonly string _errorMessage;

        public PlaceNotFoundException(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        public string ErrorMessage { get { return _errorMessage; } }
    }
}
