using Company.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositories.Data
{
	public class DBAContext : DbContext
	{
		public DBAContext(DbContextOptions<DBAContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Department> Departments { get; set; }
		public DbSet<Employees> Employees { get; set; }
	}
}
