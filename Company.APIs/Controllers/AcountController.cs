using AutoMapper;
using Company.APIs.Dtos;
using Company.APIs.Erorrs;
using Company.Core.Entities.Identity;
using Company.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Company.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AcountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ITokenServices _tokenServices;
		private readonly SignInManager<AppUser> _signInManager;

		public AcountController(UserManager<AppUser> userManager,
			ITokenServices tokenServices,
			SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_tokenServices = tokenServices;
			_signInManager = signInManager;
		}

		[HttpPost("Login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto login)
		{
			var user = await _userManager.FindByEmailAsync(login.Email);
			if (user == null) return Unauthorized(new ApiResponse(401));
			var result = await _signInManager.CheckPasswordSignInAsync(user,login.Password,false);
			if (!result.Succeeded) return Unauthorized(new ApiResponse(401));
			

			return Ok(new UserDto
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = await _tokenServices.CreateToken(user, _userManager)
			});
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (CheckEmailExistAsync(registerDto.Email).Result.Value)
			{
				return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = new[] { "Email address is in use" } });
			}
			var user = new AppUser()
			{
				DisplayName = registerDto.DisplayName,
				Email = registerDto.Email,
				UserName = registerDto.Email.Split('@')[0],
				PhoneNumber = registerDto.Phone
			};

			var result = await _userManager.CreateAsync(user, registerDto.Password);
			
			if (!result.Succeeded) return BadRequest(new ApiResponse(400));

			return Ok(new UserDto()
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = await _tokenServices.CreateToken(user, _userManager)
			});
		}

		[HttpGet("emailexists")]
		public async Task<ActionResult<bool>> CheckEmailExistAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email) != null;
		}

	}
}
