using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _repository;
        public LocationService(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<Location>> GetCityListAsync()
        {
            var locationList = await _repository.GetAllAsync();
            return locationList;
        }
    }
}
