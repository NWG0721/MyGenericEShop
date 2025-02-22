using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Review : BaseEntity
	{
		public Guid UserID { get; set; }
		public Guid ProductID { get; set; }
		public int Rating { get; set; } // 1 to 5
		public string Comment { get; set; }
		public DateTime ReviewDate { get; set; } = DateTime.UtcNow;

		public User User { get; set; }
		public Product Product { get; set; }
	}
}
