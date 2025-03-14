using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Installment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Length { get; set; }
        public float PercentOfOverpayment { get; set; }

        public Installment(int id, int userId, int length, float percentOfOverpayment)
        {
            this.Id = id;
            this.UserId = userId;
            this.Length = length;
            this.PercentOfOverpayment = percentOfOverpayment;
        }
    }
}
