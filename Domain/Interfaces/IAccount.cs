using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccount
    {
        int Id { get; }
        decimal Balance { get; }
        bool IsLocked { get; }

        IAccountOwner Owner { get; }
    }
}
