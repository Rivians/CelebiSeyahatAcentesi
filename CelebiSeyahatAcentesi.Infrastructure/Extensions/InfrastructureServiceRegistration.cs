using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Domain.Constants;
using CelebiSeyahat.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection("JwtSettings").Bind(jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            });

            services.AddScoped<ITokenService, TokenService>();

            return services;

            // THIS ANAHTAR KELİMESİ NEDEN KULLANILDI ?

            // Metodun bir extension method olduğunu belirtir.
            // Bu sayede IServiceCollection üzerinde doğrudan çağrılabilir : services.AddInfrastructureServices(configuration);

            // "this" olmadan bu yapı bir genişletme metodu olmaz ve normal bir statik metod olarak çağrılması gerekirdi: ServiceCollectionExtensions.AddInfrastructureServices(services, configuration);

        }
    }
}
