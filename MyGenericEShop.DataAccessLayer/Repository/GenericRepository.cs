using Microsoft.EntityFrameworkCore;
using MyGenericEShop.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		#region Constructor

		private readonly DbContext db;
		public GenericRepository(DbContext _db)
		{
			db = _db ?? throw new ArgumentNullException(nameof(_db));
		}

		#endregion


		#region Select

		public async Task<List<T>> SelectAllAsync()
		{
			return await db.Set<T>().ToListAsync();
		}

		public async Task<List<T>> FilteredSelectionAsync(Expression<Func<T, bool>> expression)
		{
			return await db.Set<T>().Where(expression).ToListAsync();
		}

		#endregion

		#region Insert

		public async Task<bool> InsertAsync(T entity)
		{

			try
			{
				var entry = await db.Set<T>().AddAsync(entity);
				return true;
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}

		#endregion

		#region Update

		public async Task<bool> UpdateAsync(T entity)
		{
			try
			{
				var entry = db.Set<T>().Update(entity);
				return true;
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}

		#endregion

		#region Delete
		public async Task<bool> DeleteAsync(T entity)
		{
			try
			{

				var entry = db.Set<T>().Remove(entity);

				return true;

			}
			catch (Exception)
			{
				throw new Exception();
			}
		}
		public async Task<bool> DeleteByIdAsync(Guid id)
		{
			var entity = await db.Set<T>().FindAsync(id);
			if (entity == null) return false;

			db.Set<T>().Remove(entity);
			return true;
		}

		public async Task<bool> SoftDeleteAsync(T entity)
		{
			//if (entity is ISoftDeletable softDeletable)
			//{
			//	softDeletable.IsDeleted = true;
			//	await UpdateAsync(entity);
			//}

			// develop for soon as fu.ck
			return false;
		}

		#endregion


		#region SaveChanges

		public Task<int> SaveChangesAsync()
		{
			return db.SaveChangesAsync();
		}

		#endregion
	}
}
