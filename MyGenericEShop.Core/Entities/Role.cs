using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class Role : BaseEntity
	{
		[MinLength(2)]
		public string Name { get; set; }

		public string Description { get; set; }


		public List<User> Users { get; set; } = new List<User>();
	}
}
