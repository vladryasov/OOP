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
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public int OwnerId { get; set; }

        public BaseAccount(int id, bool isLocked, int ownerId)
        {
            this.Id = id;
            this.Balance = 0;
            this.IsLocked = isLocked;
            this.OwnerId = ownerId;
        }
    }
}
