using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Repositories
{
    public interface IMyTransactionRepository : IRepository<MyTransaction>
    {
        Task<List<MyTransaction>> GetByAccountIdAsync(int fromAccountid);
    }
}
