using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Dtos.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string? Password { get; set; }

    }
}
