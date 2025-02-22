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
		public Guid? CategoryID { get; set; }
		public DateTime? ProductionDate { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public Guid? MongoMoreInfoID { get; set; }
		public ICollection<Price> Prices { get; set; } = new List<Price>();
		public Category Category { get; set; }
		public List<Review> reviews { get; set; } = new List<Review> ();
	}
}
