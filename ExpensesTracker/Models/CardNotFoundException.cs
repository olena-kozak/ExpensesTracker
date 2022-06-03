namespace ExpensesTracker.Models
{
    public class CardNotFoundException : Exception
    {
        private readonly string _errorMessage;

        public CardNotFoundException(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        public string ErrorMessage { get { return _errorMessage; } }
    }
}
