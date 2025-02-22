using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class CategoryType : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }


		public List<Category> Categories { get; set; } = new List<Category>();
	}
}
