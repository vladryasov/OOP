using Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalaryProject
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public int EnterpriseAccountId { get; set; }
        public bool IsApproved { get; set; }
        public decimal Salary {  get; set; }
        public List<int> EmployeeAccountsIds { get; set; }

        public SalaryProject(int id, int bankId, int enterpriseAccountId, bool isApproved, decimal salary, List<int> employeeAccountsIds)
        {
            this.Id = id;
            this.BankId = bankId;
            this.EnterpriseAccountId = enterpriseAccountId;
            this.IsApproved = isApproved;
            this.Salary = salary;
            this.EmployeeAccountsIds = employeeAccountsIds;
        }
    }
}
