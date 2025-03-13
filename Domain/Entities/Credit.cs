using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Credit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal SumOfLoan { get; set; }
        public DateTime EndDate{ get; set; }
        public float InterestRate { get; set; }

        public bool IsApproved { get; set; }

        public Credit(int userId, decimal sumOfLoan, DateTime endDate, float interestRate, bool isApproved)
        {
            this.UserId = userId;
            this.SumOfLoan = sumOfLoan;
            this.EndDate = endDate;
            this.InterestRate = interestRate;
            this.IsApproved = isApproved;
        }
    }
}
