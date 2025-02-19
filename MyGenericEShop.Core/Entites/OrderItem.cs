using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entites
{
	public class OrderItem : BaseEntity
	{
		public Guid OrderID { get; set; }
		public Guid ProductID { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public Order Order { get; set; }
		public Product Product { get; set; }
	}
}
