using Domain.Interfaces;
using System;
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
        public IAccountOwner Owner { get; set; }

        public EnterpriseAccount(int id, bool isLocked, IAccountOwner owner)
        {
            this.Id = id;
            this.Balance = 0;
            this.IsLocked = isLocked;
            this.Owner = owner;
        }
    }
}
