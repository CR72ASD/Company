using System.ComponentModel.DataAnnotations;

namespace Company.APIs.Dtos
{
	public class LoginDto
	{
		[Required(ErrorMessage = "The Email Is Required")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
