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
    public class EnterpriseAccountService : IEnterpriseAccountService
    {
        private readonly IEnterpriseAccountRepository _enterpriseAccountRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseAccountService(IEnterpriseAccountRepository enterpriseAccountRepository, IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseAccountRepository = enterpriseAccountRepository;
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<bool> OpenAccount(int id)
        {
            var owner = await _enterpriseRepository.GetByIdAsync(id);

            if (owner == null) return false;

            var accid = await _enterpriseAccountRepository.CountAsync();

            var enterpriseAccount = new EnterpriseAccount(accid,true, owner); 

            await _enterpriseAccountRepository.AddAsync(enterpriseAccount);

            return true;
        }

        public async Task<bool> CloseAccount(int id)
        {
            var account = await _enterpriseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _enterpriseAccountRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> Deposit(int id, decimal amount)
        {
            var account = await _enterpriseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance += amount;

            await _enterpriseAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Withdraw(int id, decimal amount)
        {
            var account = await _enterpriseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance -= amount;

            await _enterpriseAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Block(int id)
        {
            var account = await _enterpriseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _enterpriseAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Unblock(int id)
        {
            var account = await _enterpriseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = false;

            await _enterpriseAccountRepository.UpdateAsync(account);
            return true;
        }
    }
}
