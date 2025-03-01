using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccountOwner
    {
        int Id { get; }
        string Name { get; }
    }
}
