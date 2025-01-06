using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Application.Features.NotificationFeatures.Queries;
using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
	public class NotificationService : INotificationService
	{
		private readonly IRepository<Notification> _repository;
		public NotificationService(IRepository<Notification> repository)
		{
			_repository = repository;
		}


		public async Task AddNotificationAsync(string customerId, string type, string message)
		{
			var notification = new Notification
			{
				CustomerId = customerId,
				Type = type,
				Message = message,
				IsRead = false
			};

			await _repository.AddAsync(notification);
		}

		public async Task<List<GetUserNotificationsQueryResponse>> GetUserNotificationListAsync(string customerId)
		{
			var notifyList = await _repository.GetAllAsync(n => n.CustomerId == customerId);

			var responseList = notifyList.Select(n => new GetUserNotificationsQueryResponse
			{
				Id = n.Id,
				CustomerId = customerId,
				Type = n.Type,
				Message = n.Message,
				IsRead = n.IsRead
			}).ToList();

			return responseList;
		}
	}
}
