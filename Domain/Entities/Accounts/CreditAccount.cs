using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Accounts
{
    public class CreditAccount : ICreditAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public int OwnerId { get; set; }

        public int CreditLimit {  get; set; }
        public float InterestRate {  get; set; }
        public DateTime CreditEndDate { get; set; }

        public CreditAccount(int id, bool isLocked, int ownerId, int creditLimit, float interestRate, DateTime creditEndDate)
        {
            Id = id;
            Balance = 0;
            IsLocked = isLocked;
            OwnerId = ownerId;
            CreditLimit = creditLimit;
            InterestRate = interestRate;
            CreditEndDate = creditEndDate;
        }
    }
}
