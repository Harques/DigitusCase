using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Type { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public Category Category { get; set; }

    }
}
