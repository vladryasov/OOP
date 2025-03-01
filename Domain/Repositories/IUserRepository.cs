using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailIdAsync(string email);
        Task<int> CountByRoleAsync(UserRole role);
    }
}
