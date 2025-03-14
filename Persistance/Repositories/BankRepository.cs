using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly BankDbContext _dbContext;

        public BankRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Bank>> GetAllAsync()
        {
            return await _dbContext.Banks.ToListAsync();
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            return await _dbContext.Banks
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Banks.CountAsync();
        }

        public async Task<Bank> AddAsync(Bank entity)
        {
            await _dbContext.Banks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Bank> UpdateAsync(Bank entity)
        {
            _dbContext.Banks.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Bank> DeleteAsync(int id)
        {
            var bank = await _dbContext.Banks.FindAsync(id);

            if (bank != null)
            {
                _dbContext.Banks.Remove(bank);
                await _dbContext.SaveChangesAsync();
            }

            return bank!;
        }
        public async Task<Bank> GetByBICAsync(string bic)
        {
            return await _dbContext.Banks.
                FirstOrDefaultAsync(b => b.BIC == bic);
        }
    }
}
