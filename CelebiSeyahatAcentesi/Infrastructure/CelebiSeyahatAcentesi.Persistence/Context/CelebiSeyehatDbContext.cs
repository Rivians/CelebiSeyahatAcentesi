using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Identity;
using CelebiSeyahat.Persistence.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Context
{
    public class CelebiSeyehatDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        private readonly DatabaseSettings _databaseSettings;

        // IOptions, bir sınıfa yapılandırma ayarlarını dinamik olarak yüklemek için kullanılan bir arayüzdür. Value özelliği sayesinde configüre yada bind edilmiş değerini alıyoruz
        public CelebiSeyehatDbContext(DbContextOptions options, IOptions<DatabaseSettings> databaseSettings) : base(options)
        {
            _databaseSettings = databaseSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Eğer başka bir yerde yapılandırma yapılmadıysa, burada veritabanı sağlayıcısını manuel olarak tanımlar.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_databaseSettings.DefaultConnection);
            }

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelReservation> HotelReservations { get; set; }
        public DbSet<LoyaltyPoint> LoyaltyPoints { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TransportationCompany> TransportationCompanys { get; set; }
        public DbSet<Trip> Trips { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Basket)   // Customer bir Basket'e sahiptir.
                .WithOne(b => b.Customer)  // Basket bir Customer'a sahiptir.
                .HasForeignKey<Basket>(b => b.CustomerId) // Basket tablosunda CustomerId foreign key olarak tanımlanmıştır.
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.AppUser)
                .WithOne(c => c.Customer)
                .HasForeignKey<Customer>(c => c.AppUserId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Basket)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BasketId);

            modelBuilder.Entity<HotelReservation>()
                .HasOne(h => h.Customer)
                .WithMany(c => c.HotelReservations)
                .HasForeignKey(h => h.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TransportationCompany)
                .WithMany(tc => tc.Tickets)
                .HasForeignKey(t => t.TransportationCompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BasketItem>()
                .HasOne(b => b.Ticket)
                .WithMany() // tek taraflı ilişki kuruyoruz
                .HasForeignKey(b => b.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BasketItem>()
                .HasOne(b => b.HotelReservation)
                .WithMany() // tek taraflı ilişki kuruyoruz
                .HasForeignKey(b => b.HotelReservationId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
