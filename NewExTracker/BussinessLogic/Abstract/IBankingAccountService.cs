using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IBankingAccountService
    {
        public bool UpdateAlailibleSum(BankingAccount bankingAccountId);

        public string GetAlailibleSum(BankingAccount bankingAccount, decimal sum, string receivedAvailiableSum);

    }
}
