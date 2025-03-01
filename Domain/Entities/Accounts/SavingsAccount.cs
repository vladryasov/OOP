using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Accounts
{
    public class SavingsAccount : ISavingsAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public IAccountOwner Owner { get; set; }
        public float InterestRate { get; set; }

        public SavingsAccount(int id, decimal balance, bool isLocked, IAccountOwner owner, float interestRate)
        {
            this.Id = id;
            this.Balance = balance;
            this.IsLocked = isLocked;
            this.Owner = owner;
            this.InterestRate = interestRate;
        }
    }
}
