using Company.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Company.APIs.Dtos
{
    public class EmployeesDto
    {
        public string Name { get; set; }
        [MaxLength(14)]
        [MinLength(14)]
        public string NationalId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
