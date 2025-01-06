using CelebiSeyahat.Application.Features.PaymentFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Abstractions
{
	public interface IPaymentService
	{
		Task<ProcessPaymentCommandResponse> ProcessPaymentAsync(ProcessPaymentCommand request);
	}
}
