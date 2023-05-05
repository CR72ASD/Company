using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> GetByIdAsync(int Id);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		Task<int> Complete();
	}
}
