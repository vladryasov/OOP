﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBankRepository : IRepository<Bank>
    {
        Task<Bank> GetByBICAsync(string bic);
    }
}
