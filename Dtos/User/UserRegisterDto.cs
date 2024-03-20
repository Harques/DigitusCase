using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Dtos.User
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string? Password { get; set; }
    }
}
