using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IBankingAccountService
    {
        public string GetAlailibleSum(BankingAccount bankingAccount, decimal sum, string receivedAvailiableSum);

    }
}
