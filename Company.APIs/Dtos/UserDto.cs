using System.ComponentModel.DataAnnotations;

namespace Company.APIs.Dtos
{
	public class UserDto
	{
		public string DisplayName { get; set; }
		[EmailAddress]
		public string Email { get; set; }
        public string Token { get; set; }
    }
}
