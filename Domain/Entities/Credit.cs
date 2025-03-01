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

        public Credit(int userid, decimal sumOfLoan, DateTime endTime, float interestRate, bool isApproved)
        {
            this.UserId = userid;
            this.SumOfLoan = sumOfLoan;
            this.EndDate = endTime;
            this.InterestRate = interestRate;
            this.IsApproved = isApproved;
        }
    }
}
