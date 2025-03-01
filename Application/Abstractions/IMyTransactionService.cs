using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IMyTransactionService
    {
        public Task<bool> MakeTransaction(int outid, int inid, decimal total);
    }
}
