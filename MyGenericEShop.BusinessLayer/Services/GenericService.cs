using Microsoft.EntityFrameworkCore;
using MyGenericEShop.Core.Entities;
using MyGenericEShop.Core.Interfaces.Repositories;
using MyGenericEShop.Core.Interfaces.Services;
using MyGenericEShop.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.BusinessLayer.Services
{
	public class GenericService<T> : IGenericService<T> where T : BaseEntity
	{
		#region Constructors

		private readonly IGenericRepository<T> _repository;
		public GenericService(IGenericRepository<T> repository)
		{
			_repository = repository;
		}

		#endregion

		#region Select

		public async Task<List<T>> GetAllAsync()
			=> await _repository.SelectAllAsync();

		public async Task<List<T>> FilterAsync(Expression<Func<T, bool>> predicate)
			=> await _repository.FilteredSelectionAsync(predicate);


		public async Task<T> GetByIdAsync(Guid id)
			=> await _repository.SelectByID(id);
		
		#endregion

		#region Insert

		public async Task<int> InsertAndSaveAsync(T entity)
		{
			bool isOk = await _repository.InsertAsync(entity);
			if (isOk)
				return await SaveChangesAsync();
			else
				return -1;
		}

		public async Task<bool> InsertAsync(T entity)
			=> await _repository.InsertAsync(entity);

		#endregion

		#region Update

		public async Task<int> UpdateAndSaveAsync(T entity)
		{
			bool isOk = await _repository.UpdateAsync(entity);
			if (isOk)			
				return await SaveChangesAsync();			
			else			
				return -1;			
		}
		public async Task<bool> UpdateAsync(T entity)
			=> await _repository.UpdateAsync(entity);
		
		#endregion

		#region Delete

		public async Task<int> DeleteAndSaveAsync(Guid id)
		{
			bool isOk = await _repository.DeleteByIdAsync(id);
			if (isOk)
				return await SaveChangesAsync();
			else
				return -1;
		}

		public async Task<bool> DeleteAsync(Guid id)
			=> await _repository.DeleteByIdAsync(id);

		public async Task<bool> DeleteAllAsync(T entity)		
			=> await _repository.DeleteAsync(entity);
		
		public async Task<int> DeleteAllAndSaveAsync(T entity)
		{
			bool isOk = await _repository.DeleteAsync(entity);
			if (isOk)
				return await SaveChangesAsync();
			else
				return -1;
		}

		#endregion

		#region SaveChanges

		public Task<int> SaveChangesAsync()
			=> _repository.SaveChangesAsync();

		#endregion

	}
}
