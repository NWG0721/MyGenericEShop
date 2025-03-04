using MyGenericEShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Interfaces.Services
{
	public interface IGenericService<T> where T : BaseEntity
	{
		#region Select

		public List<T> GetAll();

		public T Filter(Guid id);

		#endregion

		#region Insert

		public bool InsertAndSave(T entity);

		public bool Insert(T entity);

		#endregion

		#region Update

		public bool UpdateAndSave(T entity);
		public bool Update(T entity);

		#endregion

		#region Delete

		public bool DeleteAndSave(Guid id);
		public bool Delete(Guid id);

		#endregion


	}
}
