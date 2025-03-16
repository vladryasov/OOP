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
    public class SavingsAccountService : ISavingsAccountService
    {
        private readonly ISavingsAccountRepository _savingsAccountRepository;
        private readonly IUserRepository _userRepository;

        public SavingsAccountService(ISavingsAccountRepository savingsAccountRepository, IUserRepository userRepository)
        {
            _savingsAccountRepository = savingsAccountRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> OpenAccount(int id)
        {
            var owner = await _userRepository.GetByIdAsync(id);

            if (owner == null) return false;

            var ownerid = owner.Id;

            var accid = await _savingsAccountRepository.CountAsync() + 1;

            var savingsAccount = new SavingsAccount(accid, 0, false, ownerid, 0.05f);

            await _savingsAccountRepository.AddAsync(savingsAccount);

            return true;
        }

        public async Task<bool> CloseAccount(int id)
        {
            var account = await _savingsAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _savingsAccountRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> Deposit(int id, decimal amount)
        {
            var account = await _savingsAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance += amount;

            await _savingsAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Withdraw(int id, decimal amount)
        {
            var account = await _savingsAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance -= amount;

            await _savingsAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Block(int id)
        {
            var account = await _savingsAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _savingsAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Unblock(int id)
        {
            var account = await _savingsAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = false;

            await _savingsAccountRepository.UpdateAsync(account);
            return true;
        }
    }
}
