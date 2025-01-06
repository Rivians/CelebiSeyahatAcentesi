using AutoMapper;
using CelebiSeyahat.Application.Features.CustomerFeatures.Queries;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Mapping.CustomerMaps
{
	public class CustomerMapping : Profile
	{
        public CustomerMapping()
        {
            CreateMap<Customer, GetCustomerListWithAllQueryResponse>()
                .ForMember(c => c.Ticket, opt => opt.MapFrom(src => src.Tickets))
                .ForMember(c => c.HotelReservation, opt => opt.MapFrom(src => src.HotelReservations))
                .ForMember(c => c.Payment, opt => opt.MapFrom(src => src.Payments));
        }
    }
}
