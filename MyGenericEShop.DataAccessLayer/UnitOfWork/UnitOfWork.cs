using MyGenericEShop.Core.Entities;
using MyGenericEShop.Core.Interfaces.Repositories;
using MyGenericEShop.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.DataAccessLayer.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MyGenericEshopDBContext _context;
		private readonly Dictionary<Type, object> _repositories = new();

		public UnitOfWork(MyGenericEshopDBContext context)
		{
			_context = context;
		}

		public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity
		{
			var type = typeof(T);
			if (!_repositories.ContainsKey(type))
			{
				var repository = new GenericRepository<T>(_context);
				_repositories[type] = repository;
			}
			return (IGenericRepository<T>)_repositories[type];
		}

		public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

		public void Dispose() => _context.Dispose();
	}

}
