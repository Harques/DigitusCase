using System.ComponentModel.DataAnnotations;

namespace DigitusCase.Dtos.Category
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Description { get; set; }
        public List<int>? SubCategoryIds { get; set; }
    }
}
