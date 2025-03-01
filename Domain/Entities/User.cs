using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class User : IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportId { get; set; }
        public bool IsCitizen { get; set; }

        public string WorkPlace { get; set; }

        public UserRole Role { get; set; }
        public List<UserPermission> Permissions { get; set; }

        public User(int id, string fullName, string passposrtId, bool isCitizen, string phoneNumber, string email, string password, UserRole role, List<UserPermission> permissions, string workPlace)
        {
            this.Id = id; 
            this.Name = fullName;
            this.PassportId = passposrtId;
            this.IsCitizen = isCitizen;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Password = password;

            this.Role = role;
            this.Permissions = permissions ?? new List<UserPermission>();
            this.WorkPlace = workPlace;
        }
    }
}
