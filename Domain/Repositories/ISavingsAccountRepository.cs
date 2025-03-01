using Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ISavingsAccountRepository : IRepository<SavingsAccount>
    {
        public Task<List<SavingsAccount>> GetByUserIdAsync(int userid);
    }
}
