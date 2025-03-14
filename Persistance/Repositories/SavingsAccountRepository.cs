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
    public class SavingsAccountRepository : ISavingsAccountRepository
    {
        private readonly BankDbContext _dbContext;

        public SavingsAccountRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SavingsAccount>> GetAllAsync()
        {
            return await _dbContext.SavingsAccounts.ToListAsync();
        }

        public async Task<SavingsAccount> GetByIdAsync(int id)
        {
            return await _dbContext.SavingsAccounts
                .FirstOrDefaultAsync(sa => sa.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.SavingsAccounts.CountAsync();
        }

        public async Task<SavingsAccount> AddAsync(SavingsAccount entity)
        {
            await _dbContext.SavingsAccounts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<SavingsAccount> UpdateAsync(SavingsAccount entity)
        {
            _dbContext.SavingsAccounts.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<SavingsAccount> DeleteAsync(int id)
        {
            var account = await _dbContext.SavingsAccounts.FindAsync(id);

            if (account != null)
            {
                _dbContext.SavingsAccounts.Remove(account);
                await _dbContext.SaveChangesAsync();
            }

            return account!;
        }

        public async Task<List<SavingsAccount>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.SavingsAccounts
                .Where(sa => sa.OwnerId == userId)
                .ToListAsync();
        }
    }
}
