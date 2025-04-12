using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MyGenericEShop.Core.Entities;
using MyGenericEShop.Core.Interfaces.Repositories;
using MyGenericEShop.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.BusinessLayer.Services
{
	public class UserService : IUserService
	{

		#region Constructors

		private readonly IGenericRepository<User> _repository;
		public UserService(IGenericRepository<User> repository)
		{
			_repository = repository;

		}

		#endregion

		Task<int> IUserService.AddManyUsersAndSaveAsync(List<User> users)
		{
			throw new NotImplementedException();
		}

		Task<bool> IUserService.AddManyUsersAsync(List<User> users)
		{
			throw new NotImplementedException();
		}

		Task<int> IUserService.AddNewUserAndSaveAsync(User user)
		{
			throw new NotImplementedException();
		}

		Task<bool> IUserService.AddNewUserAsync(User user)
		{
			throw new NotImplementedException();
		}

		Task<int> IUserService.DeleteAllUsersAndSaveAsync()
		{
			throw new NotImplementedException();
		}

		Task<bool> IUserService.DeleteAllUsersAsync()
		{
			throw new NotImplementedException();
		}

		Task<int> IUserService.DeleteManyUsersAndSaveAsync(Expression<Func<User, bool>> expression)
		{
			throw new NotImplementedException();
		}

		Task<bool> IUserService.DeleteManyUsersAsync(Expression<Func<User, bool>> expression)
		{
			throw new NotImplementedException();
		}

		Task<int> IUserService.DeleteUserAndSaveAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		Task<int> IUserService.DeleteUserAndSaveAsync(User user)
		{
			throw new NotImplementedException();
		}

		Task<bool> IUserService.DeleteUserAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		Task<bool> IUserService.DeleteUserAsync(User user)
		{
			throw new NotImplementedException();
		}

		Task<int> IUserService.EditUserAndSaveAsync(User user)
		{
			throw new NotImplementedException();
		}

		Task<bool> IUserService.EditUserAsync(User user)
		{
			throw new NotImplementedException();
		}

		Task<List<User>> IUserService.GetAllUsers()
		{
			throw new NotImplementedException();
		}

		Task<User> IUserService.GetUserByID(Guid id)
		{
			throw new NotImplementedException();
		}

		Task<List<User>> IUserService.GetUsersByFilter(Expression<Func<User, bool>> expression)
		{
			throw new NotImplementedException();
		}
	}
}

