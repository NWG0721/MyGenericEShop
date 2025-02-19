using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyGenericEShop.Core.Entites;

namespace MyGenericEShop.DataAccessLayer
{
	public class MyGenericEshopDBContext : DbContext
	{
		MyGenericEshopDBContext(DbContextOptions<MyGenericEshopDBContext> options) : base(options)
		{ }

		#region GenericDbSet

		public DbSet<T> Set<T>() where T : class => base.Set<T>();

		#endregion

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>();
			builder.Entity<Role>();
			builder.Entity<Category>();
			builder.Entity<Product>();
			builder.Entity<Price>();

			builder.Entity<User>(u =>
			{

				u.ToTable(nameof(User));
				u.HasKey(user => user.ID);
				u.HasIndex(user => user.Username).IsUnique();
				u.HasIndex(user => user.PhoneNumber).IsUnique();
				u.HasIndex(user => user.Email).IsUnique();
				u.Property(user => user.Role).IsRequired();
				u.Property(user => user.Fullname).HasMaxLength(150);
				u.Property(user => user.Email).HasMaxLength(256);

				//------------------| Relations |------------------\\

				u.HasOne(user => user.Role)
				.WithMany(role => role.Users)
				.HasForeignKey(user => user.RoleID)
				.OnDelete(DeleteBehavior.Cascade);
			});

			base.OnModelCreating(builder);
		}

	}
}
