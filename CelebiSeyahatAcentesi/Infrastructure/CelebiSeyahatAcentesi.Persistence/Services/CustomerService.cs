using CelebiSeyahat.Application.Features.CustomerFeatures.Queries;
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        async Task<List<Customer>> ICustomerService.GetCustomerListWithAllAsync()
        {
            return await _customerRepository.GetCustomerListWithAllAsync();
        }
    }
}
