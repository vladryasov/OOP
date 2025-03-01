using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ICreditService
    {
        public Task<bool> ApplyForCredit(int accountId, decimal total, DateTime endDate);
        public Task<bool> ApproveCredit(int creditId);
        public Task<bool> DeclineCredit(int creditId);

    }
}
