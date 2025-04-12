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

		//------------------| Only those not deleted |------------------\\
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(Guid id);
		Task<List<T>> FilterAsync(Expression<Func<T, bool>> predicate);
		//------------------| Only the soft deleted ones |------------------\\
		Task<List<T>> GetAllSoftDeleteAsync();
		Task<T> GetSoftDeleteByIdAsync(Guid id);
		Task<List<T>> FilteroftDeleteAsync(Expression<Func<T, bool>> predicate);

		#endregion

		#region Insert

		//------------------| Adding new record without saving changes |------------------\\
		Task<bool> AddAsync(T entity);
		Task<int> AddManyAsync(List<T> entity);

		//------------------| Adding new record with saving changes |------------------\\
		Task<bool> AddAndSaveAsync(T entity);
		Task<int> AddManyAndSaveAsync(List<T> entity);

		#endregion

		#region Update

		//------------------| Editing record without saving changes |------------------\\
		Task<bool> EditAsync(T entity);
		//------------------| Editing record with saving changes |------------------\\
		Task<int> EditAndSaveAsync(T entity);

		#endregion

		#region Delete

		//------------------| Hard delete without saving |------------------\\
		Task<bool> DeleteAsync(Guid id);
		Task<bool> DeleteManyAsync(Expression<Func<T, bool>> expression);
		//------------------| Hard delete with saving |------------------\\
		Task<int> DeleteAndSaveAsync(Guid id);
		Task<int> DeleteManyAndSaveAsync(Expression<Func<T, bool>> expression);
		//------------------| Soft delete without saving |------------------\\
		Task<bool> SoftDeleteAsync(Guid id);
		Task<bool> SoftDeleteManyAsync(Expression<Func<T, bool>> expression);
		//------------------| Soft delete with saving |------------------\\
		Task<int> SoftDeleteAndSaveAsync(Guid id);
		Task<int> SoftDeleteManyAndSaveAsync(Expression<Func<T, bool>> expression);

		#endregion
		#region Extras
		Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);

		Task<int> CountAsync();
		Task<int> CountAsync(Expression<Func<T, bool>> predicate);

		Task<bool> RestoreAsync(Guid id);
		Task<int> RestoreManyAsync(Expression<Func<T, bool>> predicate);
		#endregion
	}
}
