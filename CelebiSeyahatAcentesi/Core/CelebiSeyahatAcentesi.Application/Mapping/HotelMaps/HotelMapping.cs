using AutoMapper;
using CelebiSeyahat.Application.Features.HotelFeatures.Queries;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Mapping.HotelMaps
{
    public class HotelMapping : Profile
    {
        public HotelMapping()
        {
            CreateMap<Hotel, GetFilteredHotelsQueryResponse>()
                .ForMember(h => h.PensionType, opt => opt.MapFrom(src => src.PensionType.ToString()))  // enum to string yaptık.
                .ForMember(h => h.HotelFeatures, opt => opt.MapFrom(src => src.HotelFeatures.Select(hf => hf.Name).ToList()));
        }
    }
}
