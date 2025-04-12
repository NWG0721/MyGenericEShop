 using MyGenericEShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyGenericEShop.Core.Common.Results;

namespace MyGenericEShop.Core.Interfaces.Services
{
	public interface IUserService
	{
		#region Get

		Task<List<User>> SelectAll(CancellationToken token, Expression<Func<User, bool>> predicate = null, bool includeDeleted = false);
		Task<User> SelectByIdAsync(CancellationToken token, Guid id, bool includeDeleted = false);

		#endregion

		#region Add

		Task<OperationResult<User>> InsertAsync(CancellationToken token, User entity);
		Task<OperationResult<User>> InsertManyAsync(CancellationToken token, List<User> entities);

		#endregion

		#region Edit

		Task<OperationResult<User>> UpdateAsync(User entity);

		#endregion

		#region Remove

		Task<OperationResult<User>> DeleteAsync(User entity, bool softDelete = true);
		Task<OperationResult<List<User>>> DeleteManyAsync(CancellationToken token, Expression<Func<User, bool>> predicate, bool softDelete = true);
		Task<OperationResult<User>> DeleteByIdAsync(CancellationToken token, Guid id, bool softDelete = true);

		#endregion

		#region Restore

		Task<OperationResult<User>> RestoreAsync(CancellationToken token, Guid id);
		Task<OperationResult<List<User>>> RestoreManyAsync(CancellationToken token, Expression<Func<User, bool>> predicate);

		#endregion
	}

}
