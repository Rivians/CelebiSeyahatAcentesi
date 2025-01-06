using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.NotificationFeatures.Queries
{
	public class GetUserNotificationsQueryResponse
	{
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }        
    }
}
