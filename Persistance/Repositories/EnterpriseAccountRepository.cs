using System;
using Domain.Entities;
using Domain.Entities.Accounts;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class EnterpriseAccountRepository : IEnterpriseAccountRepository
    {
        private readonly BankDbContext _dbContext;

        public EnterpriseAccountRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EnterpriseAccount>> GetAllAsync()
        {
            return await _dbContext.EnterpriseAccounts.ToListAsync();
        }

        public async Task<EnterpriseAccount> GetByIdAsync(int id)
        {
            return await _dbContext.EnterpriseAccounts
                .FirstOrDefaultAsync(ea => ea.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.EnterpriseAccounts.CountAsync();
        }

        public async Task<EnterpriseAccount> AddAsync(EnterpriseAccount entity)
        {
            await _dbContext.EnterpriseAccounts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EnterpriseAccount> UpdateAsync(EnterpriseAccount entity)
        {
            _dbContext.EnterpriseAccounts.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EnterpriseAccount> DeleteAsync(int id)
        {
            var account = await _dbContext.EnterpriseAccounts.FindAsync(id);

            if (account != null)
            {
                _dbContext.EnterpriseAccounts.Remove(account);
                await _dbContext.SaveChangesAsync();
            }

            return account!;
        }

        public async Task<List<EnterpriseAccount>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.EnterpriseAccounts
                .Where(ea => ea.OwnerId == userId)
                .ToListAsync();
        }
    }
}
