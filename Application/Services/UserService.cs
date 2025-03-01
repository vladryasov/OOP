using Application.Abstractions;
using Domain.Enums;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<UserPermission>> SetUserPermissions(UserRole userRole)
        {
            var permissions = userRole switch
            {
                UserRole.Client => new List<UserPermission> { UserPermission.TransactionRequest, UserPermission.ApplyForALoan, UserPermission.OpenAccount, UserPermission.CloseAccount },
                UserRole.Administrator => new List<UserPermission> { UserPermission.ViewLogs, UserPermission.TotalCancellation },
                UserRole.Operator => new List<UserPermission> { UserPermission.CheckStat, UserPermission.ApplySalaryProject },
                UserRole.Manager => new List<UserPermission> { UserPermission.ApplySalaryProject, UserPermission.CheckStat, UserPermission.CancelAllOperationsOfEnterprise },
                UserRole.EnterpriseSpecialist => new List<UserPermission> { UserPermission.TransactionRequest, UserPermission.DocumentsToApprove },
                _ => new List<UserPermission> { }
            };
            return Task.FromResult(permissions);
        }

        public async Task<int> SetUserId(UserRole role)
        {
            int baseId = role switch
            {
                UserRole.Client => 1000000,
                UserRole.Administrator => 2000000,
                UserRole.Operator => 3000000,
                UserRole.EnterpriseSpecialist => 4000000,
                UserRole.Manager => 5000000,
                _ => 0
            };

            int userCount = await _userRepository.CountByRoleAsync(role);
            return baseId + userCount + 1;
        }
    }
}
