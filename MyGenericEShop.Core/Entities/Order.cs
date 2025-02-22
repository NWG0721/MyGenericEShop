using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Order : BaseEntity
	{
		public Guid UserID { get; set; }
		public decimal TotalAmount { get; set; }
		public string Status { get; set; } // Pending, Completed, Canceled
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;

		public User User { get; set; }
		public List<Payment> Payments { get; set; } = new List<Payment>();
		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
