using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccount
    {
        int Id { get; set; }
        decimal Balance { get; set; }
        bool IsLocked { get; set; }

        int OwnerId { get; set; }
    }
}
