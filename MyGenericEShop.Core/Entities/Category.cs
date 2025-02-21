using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public Guid ProductTypesID { get; set; }

		public List<Product> Products { get; set; }
		public CategoryType CategoryType { get; set; }
	}
}
