using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.NotificationFeatures.Queries
{
	public class GetUserNotificationsQueryHandler : IRequestHandler<GetUserNotificationsQuery, List<GetUserNotificationsQueryResponse>>
	{
		private readonly INotificationService _notificationService;
		public GetUserNotificationsQueryHandler(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}


		public async Task<List<GetUserNotificationsQueryResponse>> Handle(GetUserNotificationsQuery request, CancellationToken cancellationToken)
		{
			var notfyList = await _notificationService.GetUserNotificationListAsync(request.CustomerId);
			return notfyList;
		}
	}
}
