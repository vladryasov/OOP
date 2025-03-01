using Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICreditAccountRepository : IRepository<CreditAccount>
    {
        public Task<List<CreditAccount>> GetByUserIdAsync(int userid);
    }
}
