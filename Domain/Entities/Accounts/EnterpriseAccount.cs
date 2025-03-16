using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Accounts
{
    public class EnterpriseAccount : IEnterpriseAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public int OwnerId { get; set; }

        public EnterpriseAccount(int id, decimal balance, bool isLocked, int ownerId)
        {
            this.Id = id;
            this.Balance = balance;
            this.IsLocked = isLocked;
            this.OwnerId = ownerId;
        }
    }
}
