using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICreditAccount : IAccount
    {
        int CreditLimit { get; set; }
        float InterestRate { get; set; }
        DateTime CreditEndDate { get; set; }
    }
}
