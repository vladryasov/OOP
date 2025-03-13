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
        public int OwnerId { get; set; }
        public float InterestRate { get; set; }

        public SavingsAccount(int id, decimal balance, bool isLocked, int ownerId, float interestRate)
        {
            this.Id = id;
            this.Balance = balance;
            this.IsLocked = isLocked;
            this.OwnerId = ownerId;
            this.InterestRate = interestRate;
        }
    }
}
