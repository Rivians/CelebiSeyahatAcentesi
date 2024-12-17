using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsSuccessful { get; set; }
        public string CustomerId { get; set; }
        public string BasketId { get; set; }


        public Customer Customer { get; set; }
        public Basket Basket { get; set; }
    }
}
