using AutoMapper;
using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Repositories;
using CelebiSeyahat.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.CustomerFeatures.Queries
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListWithAllQuery, List<GetCustomerListWithAllQueryResponse>>
    {
        private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;
		public GetCustomerListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_mapper = mapper;
		}


		public async Task<List<GetCustomerListWithAllQueryResponse>> Handle(GetCustomerListWithAllQuery request, CancellationToken cancellationToken)
		{
			var customerList = await _customerRepository.GetCustomerListWithAllAsync();
			var response = _mapper.Map<List<GetCustomerListWithAllQueryResponse>>(customerList);
			
			return response;
		}
	}
}
