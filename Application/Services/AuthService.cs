using Application.Abstractions;
using Domain.Entities;
using Domain.Enums; 
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public AuthService(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService; 
        }
        public async Task<bool> Register(string fio, string email, string password, string phoneNumber, string passportId, bool isCitizen, UserRole role, int workPlace)
        {
            var existingUser = await _userRepository.GetByEmailIdAsync(passportId);
            if (existingUser != null)
            {
                return false;
            }

            var id = await _userService.SetUserId(role);
            var permissions = await _userService.SetUserPermissions(role);

            var user = new User(id, fio, passportId, isCitizen, phoneNumber, email, password, role, permissions, workPlace);

            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<bool> LogIn(string email, string password)
        {
            var user = await _userRepository.GetByEmailIdAsync(email);
            if (user == null || user.Password != password)
            {
                return false;
            }

            return true;
        }

        public Task<bool> LogOut(int userId)
        {
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteAccount(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if(user == null)
            {
                return false;
            }

            await _userRepository.DeleteAsync(userId);
            return true;
        }
    }
}
