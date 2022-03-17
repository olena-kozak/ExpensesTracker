using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Models;
using System.Text.RegularExpressions;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class BankingAccountService : IBankingAccountService
    {
        private IAvailiableSumHandler _availiableSumHandler;

        public BankingAccountService(IAvailiableSumHandler availiableSumHandler)
        {
            _availiableSumHandler = availiableSumHandler;
        }

        private bool CheckAlailibleSum(decimal bankingAccountAvaliableSum, decimal sum, string availiavleSumParsedFromMessage)
        {
            decimal prevBankingAccountAvailiableSum = _availiableSumHandler.GetAvailiableSumOnlyDigits(availiavleSumParsedFromMessage);
            return (bankingAccountAvaliableSum - sum) == prevBankingAccountAvailiableSum;                                               //check if the previous sum in db are the same as new availiable
        }

        public string GetAlailibleSum(BankingAccount bankingAccount, decimal sum, string receivedAvailiableSum)                          //TODO: object as parameter?
        {
            if (receivedAvailiableSum != null)
            {
                bool isAvailiableSumSame = CheckAlailibleSum(bankingAccount.AvailibleSum, sum, receivedAvailiableSum);
                if (isAvailiableSumSame)
                {
                    return receivedAvailiableSum;
                }
            }
            return null;
        }

        public bool UpdateAlailibleSum(BankingAccount bankingAccountId)
        {
            throw new NotImplementedException();
        }

    }
}
