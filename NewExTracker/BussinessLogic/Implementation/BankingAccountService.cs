using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Models;
using System.Text.RegularExpressions;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class BankingAccountService : IBankingAccountService
    {
        public bool CheckAlailibleSum(BankingAccount bankingAccount, string reveivedAvailiavleSum)
        {
            decimal bankingAccountAvaliableSum = bankingAccount.AvailibleSum;
            Regex regex = new Regex(@"\d*\.\d*\s");
            Match match = regex.Match(reveivedAvailiavleSum);
            if (match.Success)
            {
                string matchValue = match.Value.TrimEnd();
                decimal availiablesum = 0;
                Decimal.TryParse(matchValue, out availiablesum);                              //TODO: Try parse?
                return bankingAccountAvaliableSum == availiablesum;

            }
            return false;               //TODO: Throw exception
        }

        public bool CheckBankingAccountOwner(int bankingAccountId, string ownerPhoneNumber)
        {
            throw new NotImplementedException();
        }

        public int GetBankingAccountId(string ownerPhoneNumber)
        {
            throw new NotImplementedException();
        }

        public string GetAlailibleSum(int bankingAccountId, string ownerPhoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAlailibleSum(int bankingAccountId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateKredLim(int bankingAccountId)
        {
            throw new NotImplementedException();
        }
    }
}
