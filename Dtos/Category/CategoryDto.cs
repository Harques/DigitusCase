using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Dtos.Category
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<int>? SubCategoryIds { get; set; }
    }
}
