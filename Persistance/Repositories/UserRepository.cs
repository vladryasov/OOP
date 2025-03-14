using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistence;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankDbContext _dbContext;

        public UserRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmailIdAsync(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<int> CountByRoleAsync(UserRole role)
        {
            return await _dbContext.Users
                .CountAsync(u => u.Role == role);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Users.CountAsync();
        }

        public async Task<User> AddAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }

            return user!;
        }
    }
}
