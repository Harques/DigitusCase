using AutoMapper;
using DigitusCase.Dtos.Book;
using DigitusCase.Dtos.User;
using DigitusCase.Models;

namespace DigitusCase.Helpers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
