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
    public class TransportationCompanyRepository : ITransportationCompanyRepository
    {
        private readonly CelebiSeyehatDbContext _context;
        public TransportationCompanyRepository(CelebiSeyehatDbContext context)
        {
            _context = context;
        }


        public async Task<List<TransportationCompany>> GetTransportationListWithAllAsync()
        {
            return await _context.TransportationCompanies.Include(t => t.Trips).ToListAsync();
        }
    }
}
