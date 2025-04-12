using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MyGenericEShop.Core.Common.Results;
using MyGenericEShop.Core.Entities;
using MyGenericEShop.Core.Interfaces.Repositories;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		#region Constructor

		protected readonly MyGenericEshopDBContext _context;
		private readonly DbSet<T> _db;

		public GenericRepository( MyGenericEshopDBContext context)
		{
			_context = context;
			_db = _context.Set<T>();

		}

		#endregion

		//------------------| Methods |------------------\\

		#region Select

		public async Task<List<T>> SelectAll(CancellationToken token, Expression<Func<T, bool>> predicate = null, bool includeDeleted = false)
		{
			predicate ??= x => true;
			return await _db.Where(e => e.IsDelete == includeDeleted).Where(predicate).ToListAsync(token);
		}



		public async Task<T> SelectByIdAsync(CancellationToken token, Guid id, bool includeDeleted = false)
			=> await _db.Where(e => e.IsDelete == includeDeleted).FirstOrDefaultAsync(e => e.ID == id, token);

		#endregion

		#region Insert

		public async Task<OperationResult<T>> InsertAsync(CancellationToken token, T entity)
		{
			try
			{
				await _db.AddAsync(entity, token);
				if (token.IsCancellationRequested)
				{
					return new OperationResult<T>
					{
						Success = false,
						Message = "Insert Canceled",
						Data = entity,
						Code = OperationCode.Canceled
					};
				}
				return new OperationResult<T>
				{
					Success = true,
					Message = "Insert success",
					Data = entity,
					Code = OperationCode.InsertSuccess
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<T>
				{
					Success = false,
					Message = "Insert failed",
					Exception = ex,
					Code = OperationCode.InsertFailed
				};
			}
		}

		public async Task<OperationResult<T>> InsertManyAsync(CancellationToken token, List<T> entities)
		{
			try
			{
				await _db.AddRangeAsync(entities, token);
				if (token.IsCancellationRequested)
				{
					return new OperationResult<T>
					{
						Success = false,
						Message = "Insert Canceled",
						DataList = entities,
						Code = OperationCode.Canceled
					};
				}
				return new OperationResult<T>
				{
					Success = true,
					Message = "Insert success",
					DataList = entities,
					Code = OperationCode.InsertManySuccess
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<T>
				{
					Success = false,
					Message = "Insert failed",
					Exception = ex,
					Code = OperationCode.InsertManyFailed
				};
			}
		}

		#endregion

		#region Update

		public async Task<OperationResult<T>> UpdateAsync( T entity)
		{
			try
			{
				_db.Update(entity);
				return new OperationResult<T>
				{
					Success = true,
					Message = "Update success",
					Data = entity,
					Code = OperationCode.UpdateSuccess
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<T>
				{
					Success = false,
					Message = "Update failed",
					Exception = ex,
					Code = OperationCode.UpdateFailed
				};
			}
		}

		#endregion

		#region Delete

		public async Task<OperationResult<T>> DeleteAsync( T entity, bool softDelete = true)
		{
			try
			{
				if (softDelete)
				{
					entity.IsDelete = true;
					_db.Update(entity);
				}
				else
				{
					if (entity.IsDelete)
					{
						_db.Remove(entity);
					}
					else
					{
						entity.IsDelete = true;
						_db.Update(entity);
					}
				}

				return new OperationResult<T>
				{
					Success = true,
					Message = softDelete ? "Soft delete success" : "Hard delete success",
					Data = entity,
					Code = softDelete ? OperationCode.SoftDeleteSuccess : OperationCode.HardDeleteSuccess,
					ExecutionTime = DateTime.UtcNow
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<T>
				{
					Success = false,
					Message = "Delete failed",
					Exception = ex,
					Code = OperationCode.DeleteFailed,
					ExecutionTime = DateTime.UtcNow
				};
			}
		}


		public async Task<OperationResult<T>> DeleteByIdAsync(CancellationToken token, Guid id, bool softDelete = true)
		{
			try
			{
				var entity = await SelectByIdAsync(token, id);
				if (entity == null)
				{
					return new OperationResult<T>
					{
						Success = false,
						Message = "Entity not found",
					};
				}
				if (softDelete)
				{
					entity.IsDelete = true;
					_db.Update(entity);
				}
				else
				{
					_db.Remove(entity);
				}
				return new OperationResult<T>
				{
					Success = true,
					Message = "Delete success",
					Data = entity,
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<T>
				{
					Success = false,
					Message = "Delete failed",
					Exception = ex,
				};
			}
		}

		public async Task<OperationResult<List<T>>> DeleteManyAsync(CancellationToken token, Expression<Func<T, bool>> predicate, bool softDelete = true)
		{
			try
			{
				var entities = await SelectAll(token, predicate, false);
				if (!entities.Any())
				{
					return new OperationResult<List<T>>
					{
						Success = false,
						Message = "Entity not found",
					};
				}
				if (softDelete)
				{
					foreach (var entity in entities)
					{
						entity.IsDelete = true;
					}
					_db.UpdateRange(entities);
				}
				else
				{
					_db.RemoveRange(entities);
				}
				return new OperationResult<List<T>>
				{
					Success = true,
					Message = "Delete success",
					Data = entities,
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<List<T>>
				{
					Success = false,
					Message = "Delete failed",
					Exception = ex,
				};
			}
		}

		public async Task<OperationResult<T>> RestoreAsync(CancellationToken token, Guid id)
		{
			try
			{
				var entity = await SelectByIdAsync(token , id, true);

				if (entity == null)
				{
					return new OperationResult<T>
					{
						Success = false,
						Message = "Entity not found",
					};
				}

				entity.IsDelete = false;
				_db.Update(entity);

				return new OperationResult<T>
				{
					Success = true,
					Message = "Restore success",
					Data = entity,
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<T>
				{
					Success = false,
					Message = "Restore failed",
					Exception = ex,
				};
			}
		}

		public async Task<OperationResult<List<T>>> RestoreManyAsync(CancellationToken token, Expression<Func<T, bool>> predicate)
		{
			try
			{
				var entities = await SelectAll(token,x => x.IsDelete && predicate.Compile().Invoke(x), true);

				if (!entities.Any())
				{
					return new OperationResult<List<T>>
					{
						Success = false,
						Message = "Entities not found",
					};
				}

				foreach (var entity in entities)
				{
					entity.IsDelete = false;
				}
				_db.UpdateRange(entities);

				return new OperationResult<List<T>>
				{
					Success = true,
					Message = "Restore success",
					Data = entities,
				};
			}
			catch (Exception ex)
			{
				return new OperationResult<List<T>>
				{
					Success = false,
					Message = "Restore failed",
					Exception = ex,
				};
			}
		}
		#endregion
	}
}
		//public async Task<OperationResult<T>> DeleteAsync(T entity, bool softDelete = true)
		//{
		//	try
		//	{

		//		if (softDelete)
		//		{
		//			entity.IsDelete = true;
		//			_db.Update(entity);
		//			return new OperationResult<T>
		//			{
		//				Success = true,
		//				Message ="Soft delete success",
		//				Data= entity,
		//				Code = OperationCode.SoftDeleteSuccess
		//			};
		//		}

		//		else
		//		{
		//			if (entity.IsDelete)
		//			{
		//				_db.Remove(entity);
		//				return new OperationResult<T>
		//				{
		//					Success = true,
		//					Message = "Hard delete success",
		//					Data = entity,
		//					Code = OperationCode.HardDeleteSuccess
		//				};
		//			}
		//			else
		//			{
		//				entity.IsDelete = true;
		//				_db.Update(entity);
		//				return new OperationResult<T>
		//				{
		//					Success = true,
		//					Message = "Soft delete success",
		//					Data = entity,
		//					Code = OperationCode.SoftDeleteSuccess
		//				};
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		return new OperationResult<T>
		//		{
		//			Success = false,
		//			Message = "Delete failed",
		//			Exception = ex,
		//			Code = OperationCode.DeleteFailed
		//		};
		//	}
		//}