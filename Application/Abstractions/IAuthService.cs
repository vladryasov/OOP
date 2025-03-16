using Domain.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IAuthService
    {
        public Task<User> LogIn(string email, string password);
        public Task<bool> LogOut(int userId);
        public Task<bool> Register(string fio, string email, string password, string phoneNumber, string passportId, bool isCitizen, UserRole role, int workPlace);
        public Task<bool> DeleteAccount(int userId);
    }
}
