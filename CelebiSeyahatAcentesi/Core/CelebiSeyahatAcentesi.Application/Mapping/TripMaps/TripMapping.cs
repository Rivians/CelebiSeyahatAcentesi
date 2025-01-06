using AutoMapper;
using CelebiSeyahat.Application.Features.TripFeatures.Queries;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyehat.Dto.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Mapping.TripMaps
{
    public class TripMapping : Profile
    {
        public TripMapping()
        {
            CreateMap<Trip, TripDto>();

            CreateMap<Trip, GetTripListWithAllQueryResponse>()
                .ForMember(t => t.TransportationType, opt => opt.MapFrom(src => src.TransportationType.ToString()))
                .ForMember(t => t.TransportationCompany, opt => opt.MapFrom(src => src.TransportationCompany));
        }
    }
}
