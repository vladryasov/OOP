using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class SalaryProjectRepository : ISalaryRepository
    {
        private readonly BankDbContext _dbContext;

        public SalaryProjectRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SalaryProject>> GetAllAsync()
        {
            return await _dbContext.SalaryProjects.ToListAsync();
        }

        public async Task<SalaryProject> GetByIdAsync(int id)
        {
            return await _dbContext.SalaryProjects
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Banks.CountAsync();
        }

        public async Task<SalaryProject> AddAsync(SalaryProject entity)
        {
            await _dbContext.SalaryProjects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<SalaryProject> UpdateAsync(SalaryProject entity)
        {
            _dbContext.SalaryProjects.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<SalaryProject> DeleteAsync(int id)
        {
            var project = await _dbContext.SalaryProjects.FindAsync(id);

            if (project != null)
            {
                _dbContext.SalaryProjects.Remove(project);
                await _dbContext.SaveChangesAsync();
            }

            return project!;
        }

        public async Task<List<SalaryProject>> GetByBankIdAsync(int bankId)
        {
            return await _dbContext.SalaryProjects
                .Where(sp => sp.BankId == bankId)
                .ToListAsync();
        }

        public async Task<List<SalaryProject>> GetByEnterpriseIdAsync(int bankId)
        {
            return await _dbContext.SalaryProjects
                .Where(sp => sp.EnterpriseAccountId == bankId)
                .ToListAsync();
        }
    }
}
