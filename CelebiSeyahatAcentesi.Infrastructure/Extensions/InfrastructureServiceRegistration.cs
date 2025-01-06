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
            // #------------------------------------------------------ JWT BEARER CONFIGURATION ------------------------------------------------------#

            var jwtSettings = new JwtSettings();
            configuration.GetSection("JwtSettings").Bind(jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                // Gelen JWT token'ındaki tüm claims bilgilerini olduğu gibi kullanmanızı sağlar, bunu yapmadıgımızda authservice'de authenticate olmus kullanıcıyı httpcontext claimlerinden çekmeye çalışırken null dönüyor.
                options.MapInboundClaims = false;

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

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Token Authentication Failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },

                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token successfully validated.");
                        return Task.CompletedTask;
                    }
                };


            });

            // #------------------------------------------------------ MAILKIT CONFIGURATION ------------------------------------------------------#
            var smtpSetting = new SmtpSettings();

            configuration.GetSection("SmtpSettings").Bind(smtpSetting);
            services.AddSingleton(smtpSetting);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPaymentService, IyzicoPaymentService>();
            services.AddSingleton<IEmailService, EmailService>();

            return services;

            // THIS ANAHTAR KELİMESİ NEDEN KULLANILDI ?

            // Metodun bir extension method olduğunu belirtir.
            // Bu sayede IServiceCollection üzerinde doğrudan çağrılabilir : services.AddInfrastructureServices(configuration);

            // "this" olmadan bu yapı bir genişletme metodu olmaz ve normal bir statik metod olarak çağrılması gerekirdi: ServiceCollectionExtensions.AddInfrastructureServices(services, configuration);

        }
    }
}
