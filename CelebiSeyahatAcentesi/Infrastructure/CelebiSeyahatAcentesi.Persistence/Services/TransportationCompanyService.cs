using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
    public class TransportationCompanyService : ITransportationCompanyService
    {
        private readonly ITransportationCompanyRepository _repository;
        public TransportationCompanyService(ITransportationCompanyRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<TransportationCompany>> GetTransportationListWithAllAsync()
        {
            return await _repository.GetTransportationListWithAllAsync();
        }
    }
}
