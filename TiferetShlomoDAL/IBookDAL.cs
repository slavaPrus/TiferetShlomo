using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IBookDAL
    {
        Task<List<Book>> AddBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task RemoveBook(int id);
        Task<Book> UpdateBook(Book book);
        Task<List<Book>> GetBooksByPage(int skipCount, int pageSize);
        Task<List<Book>> GetSearchBooksByPage(int skipCount, int pageSize,string str);
    }
}