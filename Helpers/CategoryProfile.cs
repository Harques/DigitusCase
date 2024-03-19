using AutoMapper;
using DigitusCase.Dtos.Book;
using DigitusCase.Dtos.Category;
using DigitusCase.Models;

namespace DigitusCase.Helpers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}