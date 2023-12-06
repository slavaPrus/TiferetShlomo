using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IBookBL
    {
        void AddBook(BookDTO book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void RemoveBook(int id);
        void UpdateBook(Book book);
    }
}