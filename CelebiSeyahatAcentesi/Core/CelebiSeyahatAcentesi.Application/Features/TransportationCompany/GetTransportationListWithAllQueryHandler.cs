using AutoMapper;
using CelebiSeyahat.Application.Services;
using MediatR;
using System.Collections.Generic;

namespace CelebiSeyahat.Application.Features.TransportationCompany
{
    internal class GetTransportationListWithAllQueryHandler : IRequestHandler<GetTransportationListWithAllQuery, List<GetTransportationListWithAllQueryResponse>>
    {
        private readonly ITransportationCompanyService _transportationCompanyService;
        private readonly IMapper _mapper;
        public GetTransportationListWithAllQueryHandler(ITransportationCompanyService transportationCompanyService, IMapper mapper)
        {
            _transportationCompanyService = transportationCompanyService;
            _mapper = mapper;
        }


        public async Task<List<GetTransportationListWithAllQueryResponse>> Handle(GetTransportationListWithAllQuery request, CancellationToken cancellationToken)
        {
            var transportationCompanyList = await _transportationCompanyService.GetTransportationListWithAllAsync();

            var response = _mapper.Map<List<GetTransportationListWithAllQueryResponse>>(transportationCompanyList);

            return response;
        }
    }
}
