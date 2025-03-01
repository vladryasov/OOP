using Domain.Entities.Accounts;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEnterpriseAccountRepository : IRepository<EnterpriseAccount>
    {
        public Task<List<EnterpriseAccount>> GetByUserIdAsync(int userid);
        
    }
}
