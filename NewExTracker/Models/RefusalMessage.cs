namespace NewExTracker.Models
{
    public class RefusalMessage
    {
        public string MessageType { get; set; }
        public string DateTime { get; set; }
        public long CardNumber { get; set; }

        public string Sum { get; set; }

        public string AvailiableSum { get; set; }

        public decimal KredLim { get; set; }
        public string Place { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }

        public string OperationSubtype { get; set; }
    }
}
