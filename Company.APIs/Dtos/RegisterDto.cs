using System.ComponentModel.DataAnnotations;

namespace Company.APIs.Dtos
{
	public class RegisterDto
	{
		[Required(ErrorMessage = "The Display Name Is Required")]
		public string DisplayName { get; set; }
		[Required(ErrorMessage = "The Email Name Is Required")]
		[EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage = "The Address Name Is Required")]
		public string Address { get; set; }
		[Required(ErrorMessage = "The Phone Name Is Required")]
		[MaxLength(11)]
		[MinLength(11)]
		public string Password { get; set; }
		public string Phone { get; set; }
    }
}
