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
    public class CreditRepository : ICreditRepository
    {
        private readonly BankDbContext _dbContext;

        public CreditRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Credit>> GetAllAsync()
        {
            return await _dbContext.Credits.ToListAsync();
        }

        public async Task<Credit> GetByIdAsync(int id)
        {
            return await _dbContext.Credits
                .FirstOrDefaultAsync(ca => ca.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Credits.CountAsync();
        }

        public async Task<Credit> AddAsync(Credit entity)
        {
            await _dbContext.Credits.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Credit> UpdateAsync(Credit entity)
        {
            _dbContext.Credits.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Credit> DeleteAsync(int id)
        {
            var account = await _dbContext.Credits.FindAsync(id);

            if (account != null)
            {
                _dbContext.Credits.Remove(account);
                await _dbContext.SaveChangesAsync();
            }

            return account!;
        }

        public async Task<List<Credit>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Credits
                .Where(ca => ca.UserId == userId)
                .ToListAsync();
        }

        public async Task<Credit> GetCredit(int id, int userid)
        {
            return await _dbContext.Credits
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userid);
        }
    }
}