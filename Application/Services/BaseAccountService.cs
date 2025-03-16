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
    public class BaseAccountService : IBaseAccountService
    {
        private readonly IAccountRepository _baseAccountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;

        public BaseAccountService(IAccountRepository baseAccountRepository, IUserRepository userRepository, IEnterpriseRepository enterpriseRepository)
        {
            _baseAccountRepository = baseAccountRepository;
            _userRepository = userRepository;
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<bool> OpenAccount(int id)
        {
            var owner = await _userRepository.GetByIdAsync(id);

            if (owner == null) return false;

            var ownerid = owner.Id;

            var accid = await _baseAccountRepository.CountAsync() + 1;

            var baseAccount = new BaseAccount(accid, false, ownerid);

            var enterprise = await _enterpriseRepository.GetByIdAsync(owner.EnterpriseId);

            enterprise.AccountIds.Add(accid);

            await _enterpriseRepository.UpdateAsync(enterprise);

            await _baseAccountRepository.AddAsync(baseAccount);

            return true;
        }

        public async Task<bool> CloseAccount(int id)
        {
            var account = await _baseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _baseAccountRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> Deposit(int id, decimal amount)
        {
            var account = await _baseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance += amount;

            await _baseAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Withdraw(int id, decimal amount)
        {
            var account = await _baseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.Balance -= amount;

            await _baseAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Block(int id)
        {
            var account = await _baseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = true;

            await _baseAccountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> Unblock(int id)
        {
            var account = await _baseAccountRepository.GetByIdAsync(id);

            if (account == null) return false;

            account.IsLocked = false;

            await _baseAccountRepository.UpdateAsync(account);
            return true;
        }
    }
}
