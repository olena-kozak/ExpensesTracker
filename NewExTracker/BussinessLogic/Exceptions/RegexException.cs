namespace ExpensesTracker.BussinessLogic.Exceptions
{
    public class RegexException : Exception
    {
        private readonly string _errorMessage;

        public RegexException(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        public string ErrorMessage { get { return _errorMessage; } }
    }
}
