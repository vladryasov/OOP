using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string UNP { get; set; }

        public List<int>? AccountIds { get; set; }

        public Enterprise(int id, string type, string name, string address, string UNP, List<int>? accountIds = null)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Address = address;
            this.UNP = UNP;
            this.AccountIds = accountIds ?? new List<int>();
        }
    }
}
