using MyGenericEShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		// Select
		Task<List<T>> SelectAllAsync();
		Task<List<T>> FilteredSelectionAsync(Expression<Func<T, bool>> expression);
		Task<T> SelectByID(Guid id);

		// Insert
		Task<bool> InsertAsync(T entity);

		// Update
		Task<bool> UpdateAsync(T entity);

		// Delete
		Task<bool> DeleteAsync(T entity);
		Task<bool> DeleteByIdAsync(Guid id);
		Task<bool> SoftDeleteAsync(T entity);

		// Save Changes
		Task<int> SaveChangesAsync();
	}
}
