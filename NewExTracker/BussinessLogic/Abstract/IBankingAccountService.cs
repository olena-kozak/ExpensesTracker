using ExpensesTracker.Models;

namespace ExpensesTracker.BussinessLogic.Abstract
{
    public interface IBankingAccountService
    {
        public string UpdateAvailiableSum(BankingAccount bankingAccount, decimal sum, string receivedAvailiableSum);

    }
}
