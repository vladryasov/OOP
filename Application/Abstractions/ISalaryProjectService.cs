using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ISalaryProjectService
    {
        public Task<bool> ApplyForSalaryProject(int enterPriseAccou,int enterpriseId, int bankId, decimal salary);
        public Task<bool> ApproveSalaryProject(int salaryId);
        public Task<bool> ProcessSalaryPayments(int salaryId);
    }
}
