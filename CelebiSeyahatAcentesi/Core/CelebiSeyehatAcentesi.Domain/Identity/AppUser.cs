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


        // AppUser ile AppRole arasında çok'a çok ilişki var. Bunu manuel olarak yapmaya kalsak identity kütüphanesindeki hazır metotları kullanamıyor olucaktık.
        // Bu yüzde List<AppRole> Roles { get; set; } yapmaktansa IdentityUserRole ara tablosunu kullanıyoruz ve key'in string oldugunu söylüyoruz.
        //public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }  
        public Customer Customer { get; set; }
    }
}
