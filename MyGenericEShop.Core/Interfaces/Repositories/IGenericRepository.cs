using MyGenericEShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyGenericEShop.Core.Common.Results;

namespace MyGenericEShop.Core.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		// Select
		Task<List<T>> SelectAll(CancellationToken token, Expression<Func<T, bool>> predicate = null, bool includeDeleted = false);
		Task<T> SelectByIdAsync(CancellationToken token, Guid id, bool includeDeleted = false);

		// Insert
		Task<OperationResult<T>> InsertAsync(CancellationToken token, T entity);
		Task<OperationResult<T>> InsertManyAsync(CancellationToken token, List<T> entities);

		// Update
		Task<OperationResult<T>> UpdateAsync( T entity);

		// Delete
		Task<OperationResult<T>> DeleteAsync( T entity, bool softDelete = true);
		Task<OperationResult<List<T>>> DeleteManyAsync(CancellationToken token, Expression<Func<T, bool>> predicate, bool softDelete = true);
		Task<OperationResult<T>> DeleteByIdAsync(CancellationToken token, Guid id, bool softDelete = true);

		Task<OperationResult<T>> RestoreAsync(CancellationToken token, Guid id);
		Task<OperationResult<List<T>>> RestoreManyAsync(CancellationToken token, Expression<Func<T, bool>> predicate);
	}

}
