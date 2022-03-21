namespace NewExTracker.Data.Repository.IRepository
{
    public interface IBankingAccountRepository
    {
        public decimal GetAvailiableSum(int bankingAccoutId);

        public bool UpdateAvailiableSum(int bankingAccoutId, decimal availiableSum);
    }
}
