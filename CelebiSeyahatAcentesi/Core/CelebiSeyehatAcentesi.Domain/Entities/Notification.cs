using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string CustomerId { get; set; }


        public Customer Customer { get; set; }
    }
}
