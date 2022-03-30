using NewExTracker.Models.DTO;

namespace NewExTracker.Models
{
    public class OperationInformation
    {
        public string Message { get; set; }
        public string DateTime { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public decimal Sum { get; set; }
        public Card Card { get; set; }
        public object MessageResponse { get; set; }

    }
}
