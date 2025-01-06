using CelebiSeyahat.Application.Features.NotificationFeatures.Queries;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Services
{
	public interface INotificationService
	{
		Task AddNotificationAsync(string customerId, string type, string message);
		Task<List<GetUserNotificationsQueryResponse>> GetUserNotificationListAsync(string customerId);
	}
}
