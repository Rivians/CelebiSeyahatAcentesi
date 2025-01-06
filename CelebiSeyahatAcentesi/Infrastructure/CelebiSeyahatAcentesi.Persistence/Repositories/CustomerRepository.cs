using CelebiSeyahat.Application.Features.CustomerFeatures.Queries;
using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CelebiSeyehatDbContext _context;
        public CustomerRepository(CelebiSeyehatDbContext context)
        {
            _context = context;
        }


        public async Task<List<Customer>> GetCustomerListWithAllAsync()
        {
            var customerList = await _context.Customers.Include(c => c.Tickets).Include(c => c.HotelReservations).Include(c => c.Payments).ToListAsync();

            return customerList;
        }
    }
}
