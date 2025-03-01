using Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepository<BaseAccount> 
    {
        public Task<List<BaseAccount>> GetByUserIdAsync(int userid);
    }
}
