using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class EnterptiseRepository : IEnterpriseRepository
    {
        private readonly BankDbContext _dbContext;

        public EnterptiseRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Enterprise>> GetAllAsync()
        {
            return await _dbContext.Enterprises.ToListAsync();
        }

        public async Task<Enterprise> GetByIdAsync(int id)
        {
            return await _dbContext.Enterprises
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Enterprises.CountAsync();
        }

        public async Task<Enterprise> AddAsync(Enterprise entity)
        {
            await _dbContext.Enterprises.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Enterprise> UpdateAsync(Enterprise entity)
        {
            _dbContext.Enterprises.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Enterprise> DeleteAsync(int id)
        {
            var enterprise = await _dbContext.Enterprises.FindAsync(id);

            if (enterprise != null)
            {
                _dbContext.Enterprises.Remove(enterprise);
                await _dbContext.SaveChangesAsync();
            }

            return enterprise!;
        }

        public Task<int> CountAccountAsync(List<int> accountIds)
        {
            var count = accountIds.Count();
            return Task.FromResult(count);
        }

        public async Task<List<int>> GetAccountIdsAsync(int workplace)
        {
            var enterprise = await _dbContext.Enterprises.FindAsync(workplace);
            var ids = enterprise?.AccountIds;
            return ids!;
        }

        public async Task<bool> SetAccountAsync(int workplace, int accid)
        {
            var enterprise = await _dbContext.Enterprises.FindAsync(workplace);

            enterprise.AccountIds.Add(accid);

            _dbContext.Enterprises.Update(enterprise);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}