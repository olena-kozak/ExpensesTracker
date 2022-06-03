namespace ExpensesTracker.Models
{
    public class RegexPaterns
    {
        public static string PAYMENT_MESSAGE_PLACE_PATTERN = @"Misce[:]\s.*\.\s";
        public static string REFUSAL_MESSAGE_PLACE_PATTERN = @"Misce[:]\s.*\.";
    }
}
