using Application.Abstractions;
using Domain.Entities.Accounts;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CreditAccountService : ICreditAccountService
    {
        private readonly ICreditAccountRepository _creditAccountRepository;
        private readonly ICreditRepository _creditRepository;
        private readonly IUserRepository _userRepository;

        public CreditAccountService(ICreditAccountRepository creditAccountRepository, ICreditRepository creditRepository , IUserRepository userRepository)
        {
            _creditAccountRepository = creditAccountRepository;
            _creditRepository = creditRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> OpenAccount(int id)
        {
            var credit = await _creditRepository.GetByIdAsync(id);

            if (credit == null) return false;

            var owner = await _userRepository.GetByIdAsync(credit.UserId);

            if (owner == null) return false;

            var ownerid = owner.Id;

            var accid = await _creditAccountRepository.CountAsync() + 1;

            var creditAccount = new CreditAccount(accid, credit.SumOfLoan, !credit.IsApproved, ownerid,
                credit.SumOfLoan, credit.InterestRate, credit.EndDate);

            await _creditAccountRepository.AddAsync(creditAccount);

            return true;
        }

        public async Task<bool> CloseAccount(int id)
        {
            var account = await _creditAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _creditAccountRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> Deposit(int id, decimal amount)
        {
            var account = await _creditAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance += amount;

            await _creditAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Withdraw(int id, decimal amount)
        {
            var account = await _creditAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance -= amount;

            await _creditAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Block(int id)
        {
            var account = await _creditAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _creditAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Unblock(int id)
        {
            var account = await _creditAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = false;

            await _creditAccountRepository.UpdateAsync(account);
            return true;
        }
 
        public async Task<bool> MakePayment(int credId, decimal amount)
        {
            var creditacc = await _creditAccountRepository.GetByIdAsync(credId);

            if (creditacc == null) return false;

            creditacc.CreditLimit -= amount;

            await _creditAccountRepository.UpdateAsync(creditacc);
            return true;

        }
    }
}
