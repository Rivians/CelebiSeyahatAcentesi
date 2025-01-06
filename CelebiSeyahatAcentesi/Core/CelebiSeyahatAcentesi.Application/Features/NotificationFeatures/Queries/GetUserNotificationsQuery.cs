using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.NotificationFeatures.Queries
{
	public class GetUserNotificationsQuery : IRequest<List<GetUserNotificationsQueryResponse>>
	{
        public string CustomerId { get; set; }
    }
}
