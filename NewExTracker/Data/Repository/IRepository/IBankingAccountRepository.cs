namespace NewExTracker.Data.Repository.IRepository
{
    public interface IBankingAccountRepository
    {
        public decimal GetAvailiableSum(int bankingAccoutId);
    }
}
