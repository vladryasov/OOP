using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ISalaryRepository : IRepository<SalaryProject>
    {
        Task<List<SalaryProject>> GetByBankIdAsync(int bankid);
        Task<List<SalaryProject>> GetByEnterpriseIdAsync(int enterpriseid);
    }
}
