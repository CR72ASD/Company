using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
	public class Employees : BaseEntity
	{
        public int Id { get; set; }
		public string Name { get; set; }
		[MaxLength(14)]
		[MinLength(14)]
		public string NationalId { get; set; }

		[DataType(DataType.Date)]
		public DateTime Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
		[ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
