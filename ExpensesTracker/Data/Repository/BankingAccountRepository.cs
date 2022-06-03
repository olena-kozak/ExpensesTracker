using ExpensesTracker.Data.Repository.IRepository;
using ExpensesTracker.Models;

namespace ExpensesTracker.Data.Repository
{
    public class BankingAccountRepository : IBankingAccountRepository
    {
        private ApplicationDbContext _dbContext;
        public BankingAccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal GetAvailiableSum(int bankingAccoutId)
        {
            BankingAccount bankingAccount = _dbContext.BankingAccounts
                   .FirstOrDefault(x => x.Id == bankingAccoutId);

            return bankingAccount.AvailiableSum;
        }

        public bool UpdateAvailiableSum(int bankingAccoutId, decimal newAvailiableSum)
        {
            BankingAccount existingBankingAccount = _dbContext.BankingAccounts.Find(bankingAccoutId);
            bool isUpdated = false;
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                existingBankingAccount.AvailiableSum = newAvailiableSum;
                isUpdated = _dbContext.SaveChanges() > 0;
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }

            return isUpdated;
        }
    }
}
