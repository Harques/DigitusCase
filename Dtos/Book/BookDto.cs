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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? LastUpdatedBy { get; set; }
    }
}
