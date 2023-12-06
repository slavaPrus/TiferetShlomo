using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public class BookBL : IBookBL
    {
        private readonly IBookDAL _bookDAL;
        private IMapper Mapper;
        public BookBL(IBookDAL bookDAL, IMapper mapper)
        {
            _bookDAL = bookDAL;
            Mapper = mapper;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDAL.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookDAL.GetBookById(id);
        }

        public void AddBook(BookDTO book)
        {
            Book b = Mapper.Map<Book>(book);
            _bookDAL.AddBook(b);
        }

        public void UpdateBook(Book book)
        {
            _bookDAL.UpdateBook(book);
        }

        public void RemoveBook(int id)
        {
            _bookDAL.RemoveBook(id);
        }

    }
}
