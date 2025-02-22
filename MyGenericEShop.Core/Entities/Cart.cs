using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Cart : BaseEntity
	{
		public Guid UserID { get; set; }

		public User User { get; set; } 
		public List<CartItem> CartItems { get; set; } = new List<CartItem>();
	}
}
