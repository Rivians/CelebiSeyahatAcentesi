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
	public class HotelFeatureService : IHotelFeatureService
	{
		private readonly IRepository<HotelFeature> _hotelFeatureRepository;
		public HotelFeatureService(IRepository<HotelFeature> repository)
		{
			_hotelFeatureRepository = repository;
		}

		public async Task<List<HotelFeature>> GetHotelFeaturesAsync()
		{
			var featureList = await _hotelFeatureRepository.GetAllAsync();
			return featureList;
		}
	}
}
