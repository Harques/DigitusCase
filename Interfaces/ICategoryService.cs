using DigitusCase.Dtos.Category;

namespace DigitusCase.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryDto> Get();
        public CategoryDto GetById(int id);
        public void Create(CategoryDto categoryDto);
        public void Update(int id, CategoryDto categoryDto);
        public void DeleteById(int id);
        public bool EntityExists(int id);
    }
}
