using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.TripFeatures.Queries
{
	public class GetTripByIdQuery : IRequest<GetTripByIdQueryResponse>
	{
        public string Id { get; set; }

		public GetTripByIdQuery(string id)
		{
			Id = id;
		}
	}
}
