using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class BaseEntity
	{
		public Guid ID { get; set; } = Guid.NewGuid();
		public DateTime DateCreate { get; set; } = DateTime.UtcNow;
		public DateTime? DateModify { get; set; }
		public bool IsDelete { get; set; }
	}
}
