using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Payment : BaseEntity
	{
		public Guid OrderID { get; set; }
		public decimal Amount { get; set; }
		public string PaymentMethod { get; set; } // Card, PayPal, Crypto, etc.
		public bool IsSuccessful { get; set; }
		public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

		public Order Order { get; set; }
	
	}
}
