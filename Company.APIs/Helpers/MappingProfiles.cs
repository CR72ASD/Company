
using AutoMapper;
using Company.APIs.Dtos;
using Company.Core.Entities;

namespace Company.APIs.Helpers
{
	public class MappingProfiles: Profile
	{
        public MappingProfiles()
        {
			CreateMap<Department, DepartmentDto>().ReverseMap();
			CreateMap<Employees, EmployeesDto>().ReverseMap();
		}
	}
}
