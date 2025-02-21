using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public Guid CategoryID { get; set; }
		public DateTime? ProductionDate { get; set; }
		public DateTime? ExpirationDate { get; set; }

		public List<Price> Prices { get; set; }
		public Category Category { get; set; }
	}
}
