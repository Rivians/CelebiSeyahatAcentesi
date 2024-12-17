using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class LoyaltyPoint : BaseEntity
    {
        public int Points { get; set; }
        public string CustomerId { get; set; }
        public DateTime LastUpdated { get; set; }


        public Customer Customer { get; set; }
    }
}
