using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Repositories
{
    public interface ITransportationCompanyRepository
    {
        Task<List<TransportationCompany>> GetTransportationListWithAllAsync();
    }
}
