using CelebiSeyahat.Domain.Abstraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public AppRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
    }
}
