using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Price : BaseEntity
	{

		public Guid ProductID { get; set; }
		public decimal Value { get; set; }
		public decimal Offer { get; set; }
		public int Quantity { get; set; }

		public Product Product { get; set; }
	}
}
