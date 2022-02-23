namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IBankingAccountService
    {
        public bool UpdateAlailibleSum(int bankingAccountId);

        public string GetAlailibleSum(int bankingAccountId, string ownerPhoneNumber);

        public bool CheckAlailibleSum(int bankingAccountId);
    }
}
