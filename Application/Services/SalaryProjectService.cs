using Application.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Services
{
    public class SalaryProjectService : ISalaryProjectService
    {
        private readonly ISalaryRepository _salaryProjectRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IEnterpriseAccountRepository _enterpriseAccountRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMyTransactionService _transactionService;
        public SalaryProjectService(ISalaryRepository salaryProjectRepository, IBankRepository bankRepository, IEnterpriseAccountRepository enterpriseAccountRepository, IEnterpriseRepository enterpriseRepository, IAccountRepository accountRepository, IMyTransactionService transactionService)
        {
            _salaryProjectRepository = salaryProjectRepository;
            _bankRepository = bankRepository;
            _enterpriseAccountRepository = enterpriseAccountRepository;
            _enterpriseRepository = enterpriseRepository;
            _accountRepository = accountRepository;
            _transactionService = transactionService;
        }

        public async Task<bool> ApplyForSalaryProject(int enterpriseAccountId, int enterpriseId, int bankId, decimal salary)
        {
            var enterpriseAccount = await _enterpriseAccountRepository.GetByIdAsync(enterpriseAccountId);
            var enterprise = await _enterpriseRepository.GetByIdAsync(enterpriseId);
            var bank = await _bankRepository.GetByIdAsync(bankId);
            if (enterpriseAccount == null || bank == null)
            {
                return false;
            }

            var id = await _salaryProjectRepository.CountAsync();
            var accountIds = await _enterpriseRepository.GetAccountIdsAsync(enterprise.Id);

            var salaryProject = new SalaryProject(id, enterpriseId, bankId, false, salary, accountIds);
            await _salaryProjectRepository.AddAsync(salaryProject);

            return true;
        }

        public async Task<bool> ApproveSalaryProject(int salaryId)
        {
            var project = await _salaryProjectRepository.GetByIdAsync(salaryId);
            if(project == null)
            {
                return false;
            }

            project.IsApproved = true;

            await _salaryProjectRepository.UpdateAsync(project);
            return true;
        }

        public async Task<bool> ProcessSalaryPayments(int salaryId)
        {
            var project = await _salaryProjectRepository.GetByIdAsync(salaryId);
            var enterpriseAccount = await _enterpriseAccountRepository.GetByIdAsync(project.EnterpriseAccountId);
            if(project == null)
            {
                return false;
            }

            foreach(var accountId in project.EmployeeAccountsIds)
            {
                var account = await _accountRepository.GetByIdAsync(accountId);

                if(account == null) continue;

                await _transactionService.MakeTransaction(enterpriseAccount.Id, account.Id, project.Salary);

            }

            return true;
        }
    }
}
