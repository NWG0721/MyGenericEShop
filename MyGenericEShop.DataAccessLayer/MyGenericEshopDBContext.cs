using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyGenericEShop.Core.Entities;
using Microsoft.Identity.Client.AppConfig;

namespace MyGenericEShop.DataAccessLayer
{
	public class MyGenericEshopDBContext : DbContext
	{
		public MyGenericEshopDBContext(DbContextOptions<MyGenericEshopDBContext> options)
			: base(options)
		{ }

		#region GenericDbSet

		public DbSet<T> Set<T>() where T : class => base.Set<T>();

		#endregion

		protected override void OnModelCreating(ModelBuilder builder)
		{
			#region Building DataBases

			/*

			builder.Entity<User>();
			builder.Entity<Role>();
			builder.Entity<Category>();
			builder.Entity<Product>();
			builder.Entity<Price>();
			builder.Entity<CategoryType>();
			builder.Entity<Review>();
			builder.Entity<Payment>();
			builder.Entity<Order>();
			builder.Entity<OrderItem>();
			builder.Entity<CartItem>();
			builder.Entity<Cart>();
			builder.Entity<TelegramTokens>();
			

			*/

			#endregion

			#region Fluent API For The "User" Table

			builder.Entity<User>(user =>
			{
				user.ToTable(nameof(User));
				user.HasKey(u => u.ID);
				user.HasIndex(u => u.Username).IsUnique();
				user.HasIndex(u => u.PhoneNumber).IsUnique();
				user.HasIndex(u => u.Email).IsUnique();
				user.Property(u => u.RoleID).IsRequired();
				user.Property(u => u.Fullname).HasMaxLength(150);
				user.Property(u => u.Email).HasMaxLength(256);
				user.Property(u => u.Password).IsRequired(false);
				//------------------| Relations |------------------\\

				user.HasOne(u => u.Role)
					.WithMany(r => r.Users)
					.HasForeignKey(u => u.RoleID)
					.OnDelete(DeleteBehavior.Restrict);
			});

			#endregion

			#region Fluent API For The "Role" Table

			builder.Entity<Role>(role =>
			{
				role.ToTable(nameof(Role));
				role.HasKey(r => r.ID);
				role.Property(r => r.Name).HasMaxLength(50);
				role.Property(r => r.Description).HasMaxLength(256);

				//------------------| Relations |------------------\\
				role.HasMany(r => r.Users)
					.WithOne(u => u.Role)
					.HasForeignKey(u => u.RoleID)
					.OnDelete(DeleteBehavior.Restrict);
			});

			#endregion

			#region Fluent API For The "CategoryType" Table

			builder.Entity<CategoryType>(type =>
			{

				type.ToTable(nameof(CategoryType));
				type.HasKey(ct => ct.ID);
				type.Property(ct => ct.Name).HasMaxLength(50);
				type.Property(ct => ct.Description).HasMaxLength(256);


				//------------------| Relations |------------------\\

				type.HasMany(ct => ct.Categories).
				WithOne(c => c.CategoryType).
				HasForeignKey(c => c.CategoryTypeID).
				OnDelete(DeleteBehavior.Restrict);


			});

			#endregion

			#region Fluent API For The "Category" Table

			builder.Entity<Category>(cat =>
			{
				cat.ToTable(nameof(Category));
				cat.HasKey(c => c.ID);
				cat.Property(c => c.Name).HasMaxLength(60);
				cat.Property(c => c.Description).HasMaxLength(256);

				//------------------| Relations |------------------\\

				cat.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryID)
				.OnDelete(DeleteBehavior.Restrict);
			});

			#endregion

			#region Fluent API For The "Product" Table

			builder.Entity<Product>(pr =>
			{

				pr.ToTable(nameof(Product));
				pr.HasKey(p => p.ID);
				pr.Property(p => p.Name).HasMaxLength(150);

				//------------------| Relations |------------------\\

				pr.HasMany(p => p.Prices)
				.WithOne(price => price.Product)
				.HasForeignKey(price => price.ProductID)
				.OnDelete(DeleteBehavior.Cascade);

			});

			#endregion

			#region FLuent API For The "Price" Table

			builder.Entity<Price>(price =>
			{

				price.ToTable(nameof(Price));
				price.HasKey(p => p.ID);
				price.Property(p => p.Value).HasColumnType("Money");
				price.Property(p => p.Offer).HasColumnType("decimal(5,2)");


			});

			#endregion

			#region Fluent API For The "Review" Table

			builder.Entity<Review>(view =>
			{
				view.ToTable(nameof(Review));
				view.HasKey(r => r.ID);
				view.Property(r => r.Rating).HasColumnType("decimal(3.1)");
				view.Property(r => r.Comment).HasMaxLength(500);

				//------------------| Relations |------------------\\

				view.HasOne(r => r.User).
				WithMany(u => u.Reviews).
				HasForeignKey(r => r.UserID).
				OnDelete(DeleteBehavior.SetNull);



				view.HasOne(r => r.Product).
				WithMany(p => p.reviews).
				HasForeignKey(r => r.ProductID).
				OnDelete(DeleteBehavior.SetNull);
			});

			#endregion

			#region Fluent API For The "Payment" Table

			builder.Entity<Payment>(pay =>
			{
				pay.ToTable(nameof(Payment));
				pay.HasKey(p => p.ID);

				pay.Property(p => p.Amount).HasColumnType("decimal(18,2)");
				pay.Property(p => p.PaymentMethod).HasMaxLength(50);
				pay.Property(p => p.IsSuccessful).IsRequired();
				pay.Property(p => p.PaymentDate).HasDefaultValueSql("GETUTCDATE()");

				//------------------| Relations |------------------\\

				pay.HasOne(p => p.Order)
					.WithMany(o => o.Payments)
					.HasForeignKey(p => p.OrderID)
					.OnDelete(DeleteBehavior.Cascade);
			});

			#endregion

			#region Fluent API For The "OrderItem" Table

			builder.Entity<OrderItem>(item =>
			{

				item.ToTable(nameof(OrderItem));
				item.HasKey(o => o.ID);
				item.Property(o => o.Price).HasColumnType("Money");

				//------------------| Relations |------------------\\

				item.HasOne(o => o.Order)
				.WithMany(order => order.OrderItems)
				.HasForeignKey(o => o.OrderID)
				.OnDelete(DeleteBehavior.Cascade);

			});

			#endregion

			#region Fluent API For The "Order" Table

			builder.Entity<Order>(order =>
			{
				order.ToTable(nameof(Order));
				order.HasKey(o => o.ID);
				order.Property(o => o.TotalAmount).HasColumnType("Money");
				order.Property(o => o.Status).HasMaxLength(50);

				//------------------| Relations |------------------\\

				order.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserID)
				.OnDelete(DeleteBehavior.Cascade);

			});

			#endregion

			#region Fluent API For The "CartItem" Table

			builder.Entity<CartItem>(item =>
			{
				item.ToTable(nameof(CartItem));
				item.HasKey(c => c.ID);

				//------------------| Relations |------------------\\

				item.HasOne(c => c.Cart)
				.WithMany(cart => cart.CartItems)
				.HasForeignKey(c => c.CartID)
				.OnDelete(DeleteBehavior.Cascade);
			});

			#endregion

			#region Fluent API For The "Cart" Table

			builder.Entity<Cart>(cart =>
			{
				cart.ToTable(nameof(Cart));
				cart.HasKey(c => c.ID);

				//------------------| Relations |------------------\\

				cart.HasOne(c => c.User)
				.WithMany(u => u.Carts)
				.HasForeignKey(c => c.UserID)
				.OnDelete(DeleteBehavior.Cascade);

			});

			#endregion

			#region Fluent API For The "TelegramTokens" Table

			builder.Entity<TelegramTokens>(tt =>
			{
				tt.ToTable(nameof(TelegramTokens));
				tt.HasKey(t => t.ID);
				tt.Property(t => t.Name).HasMaxLength(50);
				tt.Property(t => t.Description).HasMaxLength(150);
				tt.Property(t => t.Description).IsRequired(false);
				tt.Property(t => t.Token).IsRequired(true);


				//------------------| Relations |------------------\\
			});

			#endregion


			base.OnModelCreating(builder);
		}

	}
}
