using MyGenericEShop.Core.Entities;
using MyGenericEShop.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.DataAccessLayer.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;
		Task<int> SaveChangesAsync();
	}
}
