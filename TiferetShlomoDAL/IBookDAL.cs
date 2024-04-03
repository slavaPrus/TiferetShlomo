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
        Task<(List<Book>, bool)> GetBooksByPage(int skipCount, int pageSize);
        Task<(List<Book>, bool)> GetSearchBooksByPage(int skipCount, int pageSize,string str);
        Task<(List<Book>, bool)> GetFilterBooksByPage(int skipCount, int pageSize, string str);
    }
}