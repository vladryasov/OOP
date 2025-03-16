using Application.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _creditRepository;
        private readonly IUserRepository _userRepository;

        public CreditService(ICreditRepository creditRepository, IUserRepository userRepository)
        {
            _creditRepository = creditRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> ApplyForCredit(int accountId, decimal total, DateTime endDate)
        {
            var account = await _userRepository.GetByIdAsync(accountId);

            if (account == null) return false;

            DateTime start = DateTime.Now;

            int duration = (endDate.Year - start.Year)*12 + endDate.Month - start.Month;
            float rate = 0;

            switch (duration)
            {
                case 6:
                    rate = 5; 
                    break;
                case 12: 
                    rate = 10;
                    break;
                case 24:
                    rate = 11.5f;
                    break;
                case 36:
                    rate = 12.5f;
                    break;
                case 60:
                    rate = 15f;
                    break;
                case 120:
                    rate = 18;
                    break;
                default:
                    rate = 20;
                    break;
            }

            var credit = new Credit(accountId, total, endDate, rate, false);

            credit.Id = await _creditRepository.CountAsync() + 1;
            await _creditRepository.AddAsync(credit);

            return true;
        }

        public async Task<bool> ApproveCredit(int creditId)
        {
            var credit = await _creditRepository.GetByIdAsync(creditId);

            if (credit == null) return false;

            credit.IsApproved = true;

            await _creditRepository.UpdateAsync(credit);

            return true;
        }

        public async Task<bool> DeclineCredit(int creditId)
        {
            var credit = await _creditRepository.GetByIdAsync(creditId);

            if (credit == null) return false;

            await _creditRepository.DeleteAsync(creditId);

            return true;
        }
    }
}
