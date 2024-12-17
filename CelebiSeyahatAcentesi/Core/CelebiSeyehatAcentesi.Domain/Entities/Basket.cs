using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public BasketType Type { get; set; }
        public bool IsCompleted { get; set; }
        public string CustomerId { get; set; }


        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
