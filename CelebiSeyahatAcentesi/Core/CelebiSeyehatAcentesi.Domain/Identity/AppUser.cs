using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
        public string LastName { get; set; }

        // PhoneNumber identity'de mevcut
        // UserName 'da mevcut

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
        

        public Customer Customer { get; set; }
    }
}
