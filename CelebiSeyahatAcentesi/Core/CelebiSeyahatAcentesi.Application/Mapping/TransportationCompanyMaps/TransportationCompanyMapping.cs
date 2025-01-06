using AutoMapper;
using CelebiSeyahat.Application.Features.TransportationCompany;
using CelebiSeyahat.Application.Features.TripFeatures.Queries;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyehat.Dto.TransportationCompany;
using CelebiSeyehat.Dto.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Mapping.TransportationCompanyMaps
{
    public class TransportationCompanyMapping : Profile
    {
        public TransportationCompanyMapping()
        {
            CreateMap<TransportationCompany, GetTransportationListWithAllQueryResponse>()
                .ForMember(c => c.Trip, opt => opt.MapFrom(src => src.Trips))
                .ForMember(c => c.TransportationType, opt => opt.MapFrom(src => src.TransportationType.ToString()));

            CreateMap<TransportationCompany, TransportationCompanyDto>()
                .ForMember(tc => tc.TransportationType, opt => opt.MapFrom(src => src.TransportationType.ToString()));

        }
    }
}
