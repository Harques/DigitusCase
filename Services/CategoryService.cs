using AutoMapper;
using DigitusCase.Data;
using DigitusCase.Dtos.Book;
using DigitusCase.Dtos.Category;
using DigitusCase.Interfaces;
using DigitusCase.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DigitusCase.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryContext _libraryContext;
        private readonly IMapper _mapper;
        public CategoryService(LibraryContext libraryContext, IMapper mapper)
        {
            _libraryContext = libraryContext;
            _mapper = mapper;
        }

        public void Create(CategoryDto categoryDto)
        {
            using (var transaction = _libraryContext.Database.BeginTransaction())
            {
                try
                {
                    var category = _mapper.Map<Category>(categoryDto);
                    _libraryContext.Categories.Add(category);
                    _libraryContext.SaveChanges();

                    if (categoryDto.SubCategoryIds == null) { transaction.Commit(); return; }

                    categoryDto.SubCategoryIds.ForEach(subCategoryId =>
                    {
                        CategoryRelationship categoryRelationship = new CategoryRelationship();
                        categoryRelationship.CategoryId = category.Id;
                        categoryRelationship.SubCategoryId = subCategoryId;
                        _libraryContext.CategoryRelationships.Add(categoryRelationship);

                    });

                    _libraryContext.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApplicationException("Exception occurred, rolling back transaction: " + ex.Message);

                }
            }
            
        }

        public void DeleteById(int id)
        {
            var category = _libraryContext.Categories.Find(id);
            _libraryContext.Categories.Remove(category);
            _libraryContext.SaveChanges();
        }

        public bool EntityExists(int id)
        {
            return _libraryContext.Categories.Any(e => e.Id == id);
        }

        public IEnumerable<CategoryDto> Get()
        {
            List<Category> categoryList = _libraryContext.Categories.ToList();
            List<CategoryDto> categoryDtoList = categoryList.Select(category => {
                var subCategoryIds = _libraryContext.CategoryRelationships.Where(categoryRelationship => categoryRelationship.CategoryId == category.Id).Select(categoryRelationship => categoryRelationship.SubCategoryId).ToList();
                var categoryList = _mapper.Map<CategoryDto>(category); 
                categoryList.SubCategoryIds = subCategoryIds;
                return categoryList;
            }).ToList();
            return categoryDtoList;

        }

        public CategoryDto GetById(int id)
        {
            Category category = _libraryContext.Categories.Find(id);
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
            categoryDto.SubCategoryIds = _libraryContext.CategoryRelationships.Where(categoryRelationship => categoryRelationship.CategoryId == category.Id).Select(categoryRelationship => categoryRelationship.SubCategoryId).ToList();
            return categoryDto;
        }

        public void Update(int id, CategoryDto categoryDto)
        {
            using (var transaction = _libraryContext.Database.BeginTransaction())
            {
                try
                {
                    var category = _libraryContext.Categories.Find(id);
                    _mapper.Map(categoryDto, category);
                    _libraryContext.SaveChanges();

                    _libraryContext.CategoryRelationships.RemoveRange(_libraryContext.CategoryRelationships.Where(x => x.CategoryId == category.Id));
                    _libraryContext.SaveChanges();

                    if (categoryDto.SubCategoryIds == null) { transaction.Commit(); return; }

                    categoryDto.SubCategoryIds.ForEach(subCategoryId =>
                    {
                        CategoryRelationship categoryRelationship = new CategoryRelationship();
                        categoryRelationship.CategoryId = category.Id;
                        categoryRelationship.SubCategoryId = subCategoryId;
                        _libraryContext.CategoryRelationships.Add(categoryRelationship);

                    });

                    _libraryContext.SaveChanges();

                    transaction.Commit();
                    _libraryContext.Database.CloseConnection();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApplicationException("Exception occurred, rolling back transaction: " + ex.Message);

                }
            }


        }
    }
}
