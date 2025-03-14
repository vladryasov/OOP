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
    public class CreditAccountRepository : ICreditAccountRepository
    {
        private readonly BankDbContext _dbContext;

        public CreditAccountRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CreditAccount>> GetAllAsync()
        {
            return await _dbContext.CreditAccounts.ToListAsync();
        }

        public async Task<CreditAccount> GetByIdAsync(int id)
        {
            return await _dbContext.CreditAccounts
                .FirstOrDefaultAsync(ca => ca.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.CreditAccounts.CountAsync();
        }

        public async Task<CreditAccount> AddAsync(CreditAccount entity)
        {
            await _dbContext.CreditAccounts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<CreditAccount> UpdateAsync(CreditAccount entity)
        {
            _dbContext.CreditAccounts.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<CreditAccount> DeleteAsync(int id)
        {
            var account = await _dbContext.CreditAccounts.FindAsync(id);

            if (account != null)
            {
                _dbContext.CreditAccounts.Remove(account);
                await _dbContext.SaveChangesAsync();
            }

            return account!;
        }

        public async Task<List<CreditAccount>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.CreditAccounts
                .Where(ca => ca.OwnerId == userId)
                .ToListAsync();
        }
    }
}
