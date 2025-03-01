using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IBaseAccountService
    {
        public Task<bool> OpenAccount(int userId);
        public Task<bool> CloseAccount(int userId);
        public Task<bool> Deposit(int userId, decimal amount);
        public Task<bool> Withdraw(int userId, decimal amount);
        public Task<bool> Block(int userId);
        public Task<bool> Unblock(int userId);
    }
}
