using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUserService
    {
        public Task<List<UserPermission>> SetUserPermissions(UserRole role);
        public Task<int> SetUserId(UserRole role);
    }
}
