using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IBookBL
    {
        void AddBook(BookDTO book);
        IEnumerable<BookDTO> GetAllBooks();
        BookDTO GetBookById(int id);
        void RemoveBook(int id);
        void UpdateBook(BookDTO book);
    }
}