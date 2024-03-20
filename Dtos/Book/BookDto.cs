using DigitusCase.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DigitusCase.Dtos.Book
{
    public class BookDto
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime DateOfIssue { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int CategoryId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? LastUpdatedBy { get; set; }
    }
}
