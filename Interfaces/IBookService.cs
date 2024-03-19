using DigitusCase.Dtos.Book;
using DigitusCase.Models;

namespace DigitusCase.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<BookDto> Get();
        public BookDto GetById(int id);
        public void Create(BookDto bookDto);
        public void Update(int id, BookDto bookDto);
        public void DeleteById(int id);
        public bool EntityExists(int id);
    }
}
