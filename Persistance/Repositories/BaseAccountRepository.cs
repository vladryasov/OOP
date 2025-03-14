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
    public class BaseAccountRepository : IAccountRepository
    {
        private readonly BankDbContext _dbContext;

        public BaseAccountRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BaseAccount>> GetAllAsync()
        {
            return await _dbContext.BaseAccounts.ToListAsync();
        }

        public async Task<BaseAccount> GetByIdAsync(int id)
        {
            return await _dbContext.BaseAccounts
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.BaseAccounts.CountAsync();
        }

        public async Task<BaseAccount> AddAsync(BaseAccount entity)
        {
            await _dbContext.BaseAccounts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<BaseAccount> UpdateAsync(BaseAccount entity)
        {
            _dbContext.BaseAccounts.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<BaseAccount> DeleteAsync(int id)
        {
            var account = await _dbContext.BaseAccounts.FindAsync(id);

            if (account != null)
            {
                _dbContext.BaseAccounts.Remove(account);
                await _dbContext.SaveChangesAsync();
            }

            return account!;
        }

        public async Task<List<BaseAccount>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.BaseAccounts
                .Where(b => b.OwnerId == userId)
                .ToListAsync();
        }
    }
}
