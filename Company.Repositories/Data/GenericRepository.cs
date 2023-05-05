using Company.Core.Entities;
using Company.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositories.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly DBAContext _context;

		public GenericRepository(DBAContext context)
		{
			_context = context;
		}

		public void Add(T entity)
			=> _context.Add(entity);

		public async Task<int> Complete()
			=> await _context.SaveChangesAsync();

		public void Delete(T entity)
			=> _context.Remove(entity);

		public async Task<IReadOnlyList<T>> GetAllAsync()
			=> await _context.Set<T>().ToListAsync();

		public async Task<T> GetByIdAsync(int Id)
			=> await _context.Set<T>().FindAsync(Id);

		public void Update(T entity)
			=> _context.Update(entity);
	}
}
