using CelebiSeyahat.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.PaymentFeatures.Commands
{
	public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, ProcessPaymentCommandResponse>
	{
		private readonly IPaymentService _paymentService;
		public ProcessPaymentCommandHandler(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}

		public async Task<ProcessPaymentCommandResponse> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
		{
			var response = await _paymentService.ProcessPaymentAsync(request);
			return response;
		}
	}
}
