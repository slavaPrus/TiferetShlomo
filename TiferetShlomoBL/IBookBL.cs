using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface IBookBL
    {
        void AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void RemoveBook(int id);
        void UpdateBook(Book book);
    }
}