using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Accounts
{
    public class BaseAccount : IAccount
    {
        public int Id { get; set; }

        public Bank Bank { get; set; }

        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public IAccountOwner Owner { get; set; }

        public BaseAccount(int id, Bank bank, bool isLocked, IAccountOwner owner)
        {
            this.Id = id;
            this.Bank = bank;
            this.Balance = 0;
            this.IsLocked = isLocked;
            this.Owner = owner;
        }
    }
}
