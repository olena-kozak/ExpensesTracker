using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;

namespace NewExTracker.Data.Repository
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
            throw new NotImplementedException();
        }

        public bool UpdateAvailiableSum(int bankingAccoutId)
        {
            BankingAccount existingBankingAccount = _dbContext.BankingAccounts.Find(bankingAccoutId);


            /*using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                _dbContext.SaveChanges();
              return transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }*/
            return _dbContext.SaveChanges() > 0;

        }


        /*public decimal GetAvailiableSum(int bankingAccoutId)
        {

        }

        public bool CheckAvailiableSum(int bankingAccoutId)
        {

        }*/

    }
}
