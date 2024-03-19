using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Dtos.User
{
    public class UserRegisterDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
