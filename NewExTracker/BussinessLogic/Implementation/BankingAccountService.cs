using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;
using System.Text.RegularExpressions;

namespace NewExTracker.BussinessLogic.Implementation
{
    public class BankingAccountService : IBankingAccountService
    {
        private IAvailiableSumHandler _availiableSumHandler;
        private IBankingAccountRepository _bankingAccountRepository;

        public BankingAccountService(IAvailiableSumHandler availiableSumHandler, IBankingAccountRepository bankingAccountRepository)
        {
            _availiableSumHandler = availiableSumHandler;
            _bankingAccountRepository = bankingAccountRepository;
        }

        public string UpdateAvailiableSum(BankingAccount bankingAccount, decimal sum, string avaliableSumFroRequest)                          //TODO: object as parameter?
        {
            if (avaliableSumFroRequest != null)
            {
                decimal parsedAvaliablSumFromRequest = _availiableSumHandler.GetAvailiableSumOnlyDigits(avaliableSumFroRequest);
                bool isAvailiableSumSame = CheckAlailibleSum(bankingAccount.AvailiableSum, sum, parsedAvaliablSumFromRequest);
                if (isAvailiableSumSame)
                {
                    bool isUpdated = UpdateAlailibleSum(bankingAccount.Id, parsedAvaliablSumFromRequest);
                    if (isUpdated)
                    {
                        return avaliableSumFroRequest;
                    }
                    else
                    {
                        throw new Exception("Something went wrong during update");
                    }

                }
            }
            return null;
        }

        private bool CheckAlailibleSum(decimal bankingAccountAvaliableSum, decimal sum, decimal parsedAvaliablSumFromRequest)
        {
            return (bankingAccountAvaliableSum - sum) == parsedAvaliablSumFromRequest;                                               //check if the previous sum in db are the same as new availiable
        }

        private bool UpdateAlailibleSum(int bankingAccountId, decimal parsedAvaliablSumFromRequest)
        {
            return _bankingAccountRepository.UpdateAvailiableSum(bankingAccountId, parsedAvaliablSumFromRequest);

        }

    }
}
