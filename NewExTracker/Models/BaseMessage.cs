namespace ExpensesTracker.Models
{
    public class BaseMessage
    {
        public string OperationSubtype { get; set; }
        public string DateTime { get; set; }
        public long CardNumber { get; set; }
        public string Sum { get; set; }
        public string Place { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
