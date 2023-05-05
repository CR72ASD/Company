using AutoMapper;
using Company.APIs.Dtos;
using Company.Core.Entities;
using Company.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IGenericRepository<Department> _repository;
		private readonly IMapper _mapper;

		public DepartmentController(IGenericRepository<Department> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<Department>>> GetAll()
		{
			var data = await _repository.GetAllAsync();
			return Ok(data);
		}

		[HttpPost("GetByID{Id}")]
		public async Task<ActionResult<IReadOnlyList<Department>>> GetById(int Id)
		{
			var data = await _repository.GetByIdAsync(Id);
			return Ok(data);
		}

		[HttpPost("Add")]
		public async Task<ActionResult> AddNew(DepartmentDto model)
		{
			if (ModelState.IsValid)
			{
				var mappedEmployee = _mapper.Map<DepartmentDto, Department>(model);
				_repository.Add(mappedEmployee);
				await _repository.Complete();
				return Ok();
			}
			return Ok(model);
		}

		[HttpPost("Update")]
		public async Task<ActionResult<Department>> Update(DepartmentDto model)
		{
			var mappedData = _mapper.Map<DepartmentDto, Department>(model);
			_repository.Update(mappedData);
			await _repository.Complete();
			return Ok(mappedData);
		}

		[HttpPost("Delete{Id}")]
		public async Task<ActionResult<Department>> Delete(DepartmentDto model , int Id)
		{
			var date = await _repository.GetByIdAsync(Id);
			_repository.Delete(date);
			await _repository.Complete();
			return Ok(date);
		}
	}
}
