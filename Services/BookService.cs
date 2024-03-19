using AutoMapper;
using DigitusCase.Data;
using DigitusCase.Dtos.Book;
using DigitusCase.Interfaces;
using DigitusCase.Models;

namespace DigitusCase.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _libraryContext;
        private readonly IMapper _mapper;

        public BookService(LibraryContext libraryContext, IMapper mapper)
        {
            _libraryContext = libraryContext;
            _mapper = mapper;
        }

        public void Create(BookDto bookDto)
        {
            _libraryContext.Books.Add(_mapper.Map<Book>(bookDto));
            _libraryContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var book = _libraryContext.Books.Find(id);
            _libraryContext.Books.Remove(book);
            _libraryContext.SaveChanges();
        }

        public IEnumerable<BookDto> Get()
        {
            return _libraryContext.Books.ToList().Select(book => _mapper.Map<BookDto>(book)).ToList();
        }

        public BookDto GetById(int id)
        {
            return _mapper.Map<BookDto>(_libraryContext.Books.Find(id));
        }

        public void Update(int id, BookDto bookDto)
        {
            var book = _libraryContext.Books.Find(id);
            _mapper.Map(bookDto, book);
            _libraryContext.SaveChanges();
        }

        public bool EntityExists(int id)
        {
            return _libraryContext.Books.Any(e => e.Id == id);
        }

    }
}
