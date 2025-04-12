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
	}
}
