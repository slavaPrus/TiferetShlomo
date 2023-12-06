using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;

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

        public void AddBook(Book book)
        {
            _bookDAL.AddBook(book);
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
