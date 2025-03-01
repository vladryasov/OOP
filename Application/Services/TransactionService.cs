using Application.Abstractions;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class TransactionService : IMyTransactionService
    {
        private readonly IMyTransactionRepository _transactionRepository; 
        private readonly IAccountRepository _accountRepository;
        public TransactionService(IMyTransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task <bool>MakeTransaction(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAcccount = await _accountRepository.GetByIdAsync(fromAccountId);
            var toAcccount = await _accountRepository.GetByIdAsync(toAccountId);

            if(fromAcccount == null || toAcccount == null || fromAcccount.Balance < amount)
            {
                return false;
            }
            fromAcccount.Balance -= amount;
            toAcccount.Balance += amount;

            int transId = await _transactionRepository.CountAsync();

            var myTransaction = new MyTransaction(transId, amount, fromAccountId, toAccountId);

            await _accountRepository.UpdateAsync(fromAcccount);
            await _accountRepository.UpdateAsync(toAcccount);
            await _transactionRepository.AddAsync(myTransaction);

            return true;
        }
    }
}
