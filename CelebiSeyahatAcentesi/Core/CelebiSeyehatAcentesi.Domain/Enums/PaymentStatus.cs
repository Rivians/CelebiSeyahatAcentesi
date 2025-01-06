using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Enums
{
	public enum PaymentStatus
	{
		Pending,	// Ödeme bekliyor
		Completed,  // Ödeme tamamlandı
		Failed,		// Ödeme başarısız
		Refunded	// Ödeme iade edildi
	}
}
