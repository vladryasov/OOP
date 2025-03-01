using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEnterpriseRepository : IRepository<Enterprise>
    {
        public Task<List<int>> GetAccountIdsAsync(string workPlace);
        public Task<int> CountAccountAsync(List<int> ids);
    }
}
