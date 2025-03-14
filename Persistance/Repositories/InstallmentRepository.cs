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
    public class InstallmentRepository : IInstallmentRepository
    {
        private readonly BankDbContext _dbContext;

        public InstallmentRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Installment>> GetAllAsync()
        {
            return await _dbContext.Installments.ToListAsync();
        }

        public async Task<Installment> GetByIdAsync(int id)
        {
            return await _dbContext.Installments
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Installments.CountAsync();
        }

        public async Task<Installment> AddAsync(Installment entity)
        {
            await _dbContext.Installments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Installment> UpdateAsync(Installment entity)
        {
            _dbContext.Installments.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Installment> DeleteAsync(int id)
        {
            var account = await _dbContext.Installments.FindAsync(id);

            if (account != null)
            {
                _dbContext.Installments.Remove(account);
                await _dbContext.SaveChangesAsync();
            }

            return account!;
        }

        public async Task<List<Installment>> GetByAccountIdAsync(int userId)
        {
            return await _dbContext.Installments
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }
    }
}
