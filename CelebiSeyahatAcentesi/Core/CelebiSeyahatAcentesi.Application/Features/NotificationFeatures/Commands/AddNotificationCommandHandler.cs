using CelebiSeyahat.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.NotificationFeatures.Commands
{
	public class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommand>
	{
		private readonly INotificationService _notificationService;
		public AddNotificationCommandHandler(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		public async Task Handle(AddNotificationCommand request, CancellationToken cancellationToken)
		{
			await _notificationService.AddNotificationAsync(request.CustomerId, request.Type, request.Message);
		}
	}
}
