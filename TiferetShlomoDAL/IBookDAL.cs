using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IBookDAL
    {
        void AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void RemoveBook(int id);
        void UpdateBook(Book book);
    }
}