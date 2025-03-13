using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MyTransaction
    {
        public int Id { get; set; } 
        public decimal? Sum { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public DateTime? Date { get; set; }

        public MyTransaction()
        {
        }

        public MyTransaction(int id, decimal sum, int fromId, int toId)
        {
            this.Id = id;
            this.Sum = sum;
            this.FromId = fromId;
            this.ToId = toId;
            this.Date = DateTime.UtcNow;
        }
    }
}
