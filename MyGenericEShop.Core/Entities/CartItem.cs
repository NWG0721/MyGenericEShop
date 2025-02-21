using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class CartItem : BaseEntity
	{
		public Guid CartID { get; set; }
		public Guid ProductID { get; set; }
		public int Quantity { get; set; }

		public Cart Cart { get; set; }
		public Product Product { get; set; }
	}
}
