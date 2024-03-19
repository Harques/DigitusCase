using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DigitusCase.Models
{
    public class User : IdentityUser<int>
    {
        public string? FullName { get; set; }
    }
}
