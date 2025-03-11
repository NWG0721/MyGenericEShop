using MyGenericEShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Interfaces.Services
{
	public interface IGenericService<T> where T : BaseEntity
	{
		#region Select

		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(Guid id);
		Task<List<T>> FilterAsync(Expression<Func<T, bool>> predicate);

		#endregion

		#region Insert

		Task<bool> InsertAsync(T entity);
		Task<int> InsertAndSaveAsync(T entity);

		#endregion

		#region Update

		Task<bool> UpdateAsync(T entity);
		Task<int> UpdateAndSaveAsync(T entity);

		#endregion

		#region Delete

		Task<bool> DeleteAsync(Guid id);
		Task<int> DeleteAndSaveAsync(Guid id);
		Task<bool> DeleteAllAsync(T entity);
		Task<int> DeleteAllAndSaveAsync(T entity);

		#endregion

		#region Saving

		Task<int> SaveChangesAsync();

		#endregion
	}
}
