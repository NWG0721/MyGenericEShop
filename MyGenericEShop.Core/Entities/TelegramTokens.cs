using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class TelegramTokens : BaseEntity
	{
		public string Name { get; set; }
		public string Token { get; set; }

		public string Description { get; set; }

	}
}
