using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.NotificationFeatures.Commands
{
	public class AddNotificationCommand : IRequest
	{
        public string CustomerId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
