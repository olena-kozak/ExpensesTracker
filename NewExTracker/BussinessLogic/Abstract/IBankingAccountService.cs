using NewExTracker.Models;

namespace NewExTracker.BussinessLogic.Abstract
{
    public interface IBankingAccountService
    {
        public string UpdateAvailiableSum(BankingAccount bankingAccount, decimal sum, string receivedAvailiableSum);

    }
}
