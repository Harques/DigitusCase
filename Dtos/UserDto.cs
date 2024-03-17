using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Dtos
{
    public class UserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

        [Required]
        public string Email { get; set; } 
        public string? Password { get; set; }

    }
}
