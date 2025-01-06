using AutoMapper;
using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Login;
using CelebiSeyahat.Application.Features.AuthFeatures.Commands.Register;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        //private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Customer> _repository;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IRepository<Customer> repository, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
            _roleManager = roleManager;
        }


        public async Task<AppUser> GetAuthenticatedUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userId))
                return null;

            //var user = await _userManager.FindByIdAsync(userId);
            //var user = await _repository.GetByIdAsync(userId);

            var customer = await _userManager.Users
                .Include(u => u.Customer)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (customer == null)
                throw new Exception("Bu AppUser'a ait Customer bilgisi bulunamadı!");

            return customer;
        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.Users.Where(x => x.Email == loginCommand.Email).FirstOrDefaultAsync(cancellationToken);

            if (user == null) throw new Exception("Kullanıcı bulunamadı!");

            //var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginCommand.Password, lockoutOnFailure : false);

            var result = await _userManager.CheckPasswordAsync(user, loginCommand.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenService.GenerateToken(user, roles);
                LoginCommandResponse response = _mapper.Map<LoginCommandResponse>(token);
                return response;
            }
            else { throw new Exception("Hatalı giriş!"); }
        }

        public async Task RegisterAsync(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerCommand);
            IdentityResult result = await _userManager.CreateAsync(appUser, registerCommand.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }

            Customer customer = new Customer
            {
                FirstName = registerCommand.Name,
                LastName = registerCommand.LastName,
                Email = registerCommand.Email,
                PhoneNumber = registerCommand.PhoneNumber,
                AppUserId = appUser.Id  // yukarıda appUser olusturuldugu için ID'si de var oluyor.
            };

            await _userManager.AddToRoleAsync(appUser, "User");
            await _repository.AddAsync(customer);
        }

        public async Task AddRoleAsync(string role)
        {
            var roleExist = await _roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new AppRole { Name = role });
            }
        }

        public async Task AssignRoleAsync(string appUserId, string role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(appUserId);

                if (user == null)
                {
                    Debug.WriteLine($"Kullanıcı bulunamadı : {appUserId}");
                    throw new Exception($"Kullanıcı bulunamadı : {appUserId}");
                }

                if (await _roleManager.RoleExistsAsync(role))
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, role);
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Rol eklenemedi : {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }

                }
                else
                    throw new Exception("Rol bulunamadı!");

            }
            catch (Exception ex)
            {
                throw new Exception($"Hata : {ex.Message}");
            }
        }
    }
}


//fail: Microsoft.EntityFrameworkCore.Query[10100]
//      An exception occurred while iterating over the results of a query for context type 'CelebiSeyahat.Persistence.Context.CelebiSeyehatDbContext'.
//      System.ObjectDisposedException: Cannot access a disposed context instance. A common cause of this error is disposing a context instance that was resolved from dependency injection and then later trying to use the same context instance elsewhere in your application. This may occur if you are calling 'Dispose' on the context instance, or wrapping it in a using statement.If you are using dependency injection, you should let the dependency injection container take care of disposing context instances.
//      Object name: 'CelebiSeyehatDbContext'.
//         at Microsoft.EntityFrameworkCore.DbContext.CheckDisposed()
//         at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies()
//         at Microsoft.EntityFrameworkCore.DbContext.Microsoft.EntityFrameworkCore.Internal.IDbContextDependencies.get_StateManager()
//         at Microsoft.EntityFrameworkCore.Query.QueryContextDependencies.get_StateManager()
//         at Microsoft.EntityFrameworkCore.Query.QueryContext.InitializeStateManager(Boolean standAlone)
//         at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.InitializeReaderAsync(AsyncEnumerator enumerator, CancellationToken cancellationToken)
//         at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.ExecuteAsync[TState, TResult](TState state, Func`4 operation, Func`4 verifySucceeded, CancellationToken cancellationToken)
//         at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.MoveNextAsync()
//      System.ObjectDisposedException: Cannot access a disposed context instance. A common cause of this error is disposing a context instance that was resolved from dependency injection and then later trying to use the same context instance elsewhere in your application. This may occur if you are calling 'Dispose' on the context instance, or wrapping it in a using statement.If you are using dependency injection, you should let the dependency injection container take care of disposing context instances.
//      Object name: 'CelebiSeyehatDbContext'.
//         at Microsoft.EntityFrameworkCore.DbContext.CheckDisposed()
//         at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies()
//         at Microsoft.EntityFrameworkCore.DbContext.Microsoft.EntityFrameworkCore.Internal.IDbContextDependencies.get_StateManager()
//         at Microsoft.EntityFrameworkCore.Query.QueryContextDependencies.get_StateManager()
//         at Microsoft.EntityFrameworkCore.Query.QueryContext.InitializeStateManager(Boolean standAlone)
//         at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.InitializeReaderAsync(AsyncEnumerator enumerator, CancellationToken cancellationToken)
//         at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.ExecuteAsync[TState, TResult](TState state, Func`4 operation, Func`4 verifySucceeded, CancellationToken cancellationToken)
//         at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.MoveNextAsync()



