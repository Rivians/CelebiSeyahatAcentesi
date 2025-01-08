using AutoMapper;
using CelebiSeyahat.Application.Features.HotelFeatures.Queries;
using CelebiSeyahat.Domain.Entities;
using CelebiSeyehat.Dto.Hotel;
using CelebiSeyehat.Dto.HotelFeature;
using CelebiSeyehat.Dto.HotelReservation;
using CelebiSeyehat.Dto.HotelRoom;
using CelebiSeyehat.Dto.HotelType;
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
				.ForMember(h => h.PensionType, opt => opt.MapFrom(src => src.PensionType.ToString()))
				.ForMember(h => h.HotelFeatures, opt => opt.MapFrom(src => src.HotelFeatures.Select(hf => hf.Name).ToList()))
				.ForMember(h => h.HotelRooms, opt => opt.MapFrom(src => src.HotelRooms))
				.ForMember(h => h.Reservations, opt => opt.MapFrom(src => src.Reservations))
				.ForMember(h => h.RoomTypes, opt => opt.MapFrom(src => src.RoomTypes))
				.ForMember(h => h.RoomTypes, opt => opt.MapFrom(src => src.RoomTypes));

			CreateMap<Hotel, GetHotelByIdQueryResponse>()
				.ForMember(h => h.PensionType, opt => opt.MapFrom(src => src.PensionType.ToString()))
				.ForMember(h => h.HotelFeatures, opt => opt.MapFrom(src => src.HotelFeatures.Select(hf => hf.Name).ToList()))
				.ForMember(h => h.HotelRooms, opt => opt.MapFrom(src => src.HotelRooms))
				.ForMember(h => h.Reservations, opt => opt.MapFrom(src => src.Reservations))
				.ForMember(h => h.RoomTypes, opt => opt.MapFrom(src => src.RoomTypes))
				.ForMember(h => h.HotelFeaturess, opt => opt.MapFrom(src => src.HotelFeatures));

			CreateMap<HotelReservation, GetHotelReservationByHotelRoomIdQueryResponse>()
				.ForMember(h => h.HotelRoom, opt => opt.MapFrom(src => src.HotelRoom));

			CreateMap<Hotel, HotelDto>(); 
			CreateMap<HotelReservation, HotelReservationDto>();
			CreateMap<HotelRoom, HotelRoomDto>();
			CreateMap<RoomType, RoomTypeDto>();				
			CreateMap<HotelFeature, HotelFeatureDto>();				
		}
	}

}
