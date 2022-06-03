using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.Data.Repository.IRepository;
using ExpensesTracker.Models;
using System.Text.RegularExpressions;

namespace ExpensesTracker.BussinessLogic.Implementation
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

        public string UpdateAvailiableSum(BankingAccount bankingAccount, decimal sum, string avaliableSumForRequest)
        {
            if (avaliableSumForRequest != null)
            {
                decimal parsedAvaliablSumFromRequest = _availiableSumHandler.GetAvailiableSumOnlyDigits(avaliableSumForRequest);
                bool isAvailiableSumSame = CheckAlailibleSum(bankingAccount.AvailiableSum, sum, parsedAvaliablSumFromRequest);
                if (isAvailiableSumSame)
                {
                    bool isUpdated = UpdateAlailibleSum(bankingAccount.Id, parsedAvaliablSumFromRequest);
                    if (isUpdated)
                    {
                        return avaliableSumForRequest;
                    }
                    else
                    {
                        throw new Exception("Something went wrong during update");
                    }
                }
                else
                {
                    throw new Exception("AvailiableSum doesn't correspond");                  //TODO: if doesn't respond
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
