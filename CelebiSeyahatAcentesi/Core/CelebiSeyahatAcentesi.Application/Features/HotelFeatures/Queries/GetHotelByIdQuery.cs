using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
	public class GetHotelByIdQuery : IRequest<GetHotelByIdQueryResponse>
	{
        public string Id { get; set; }

		public GetHotelByIdQuery(string id)
		{
			Id = id;
		}
	}
}
