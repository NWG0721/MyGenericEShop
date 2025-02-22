using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Entities
{
	public class User : BaseEntity
	{
		public Guid RoleID { get; set; }


		public string Username { get; set; }

		[MinLength(12)]
		public string Password { get; set; }

		[MaxLength(15)]
		[MinLength(5)]
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Fullname { get; set; }
		public string Zipcode { get; set; }
		public string City { get; set; }
		public string ProfileImage { get; set; }

	    public bool IsEmailVerified { get; set; }
		public bool isPhoneVerified { get; set; }
		public bool Gender { get; set; }

		public DateTime BirthDay { get; set; }
		public DateTime LastLogin { get; set; }


		public Role Role { get; set; }
		public List<Review> Reviews { get; set; } = new List<Review>();
		public List<Order> Orders { get; set; } = new List<Order>();
		public List<Cart> Carts { get; set; } = new List<Cart>();

	}
}

