using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Dtos.User
{
    public class UserRegisterDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
