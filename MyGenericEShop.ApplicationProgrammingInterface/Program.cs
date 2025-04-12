using Microsoft.EntityFrameworkCore;
using MyGenericEShop.Core.Interfaces.Repositories;
using MyGenericEShop.DataAccessLayer;
using MyGenericEShop.DataAccessLayer.Repository;
using MyGenericEShop.DataAccessLayer.UnitOfWork;

namespace MyGenericEShop.ApplicationProgrammingInterface
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			#region DBContext

			builder.Services.AddDbContext<MyGenericEshopDBContext> (options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
			});

			#endregion

			#region DependencyInjections

			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

			#endregion






			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
