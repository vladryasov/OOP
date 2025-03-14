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
    public class MyTransactionRepository : IMyTransactionRepository
    {
        private readonly BankDbContext _dbContext;

        public MyTransactionRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MyTransaction>> GetAllAsync()
        {
            return await _dbContext.MyTransactions.ToListAsync();
        }

        public async Task<MyTransaction> GetByIdAsync(int id)
        {
            return await _dbContext.MyTransactions
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.MyTransactions.CountAsync();
        }

        public async Task<MyTransaction> AddAsync(MyTransaction entity)
        {
            await _dbContext.MyTransactions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<MyTransaction> UpdateAsync(MyTransaction entity)
        {
            _dbContext.MyTransactions.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<MyTransaction> DeleteAsync(int id)
        {
            var transaction = await _dbContext.MyTransactions.FindAsync(id);

            if (transaction != null)
            {
                _dbContext.MyTransactions.Remove(transaction);
                await _dbContext.SaveChangesAsync();
            }

            return transaction!;
        }

        public async Task<List<MyTransaction>> GetByAccountIdAsync(int accid)
        {
            return await _dbContext.MyTransactions
                .Where(t => t.FromId == accid)
                .ToListAsync();
        }
    }
}
