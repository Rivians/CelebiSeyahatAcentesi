using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.CustomerFeatures.Queries
{
	public class GetCustomerIdByEmailQueryHandler : IRequestHandler<GetCustomerIdByEmailQuery, GetCustomerIdByEmailQueryResponse>
	{
		private readonly IRepository<Customer> _customerRepository;
		public GetCustomerIdByEmailQueryHandler(IRepository<Customer> customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<GetCustomerIdByEmailQueryResponse> Handle(GetCustomerIdByEmailQuery request, CancellationToken cancellationToken)
		{
			var customer = await _customerRepository.GetByFilterAsync(c => c.Email == request.Email);
			var customerId = customer.Id;

			var queryResponse = new GetCustomerIdByEmailQueryResponse()
			{
				Id = customerId
			};

			return queryResponse;
		}
	}
}
