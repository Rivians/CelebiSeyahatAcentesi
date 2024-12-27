using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Persistence.Context;
using CelebiSeyahat.Persistence.Options;
using CelebiSeyahat.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelebiSeyahat.Domain.Identity;
using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Persistence.Repositories;
using CelebiSeyahat.Application.Repositories;

namespace CelebiSeyahat.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CelebiSeyehatDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentityCore<AppUser>(options =>
            //{
            //    options.User.RequireUniqueEmail = true;
            //    //options.User.AllowedUserNameCharacters = string.Empty; 

            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.SignIn.RequireConfirmedEmail = false;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireLowercase = false;                
            //}).AddRoles<AppRole>()
            //.AddEntityFrameworkStores<CelebiSeyehatDbContext>()
            //.AddSignInManager<SignInManager<AppUser>>()
            //.AddDefaultTokenProviders();

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<CelebiSeyehatDbContext>()
            .AddDefaultTokenProviders();
            

            // ---- servisler

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ITripService, TripService>();

            // ---- repolar

            services.AddScoped<ITripRepository, TripRepository>();

        }
    }
}
