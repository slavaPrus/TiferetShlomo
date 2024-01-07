using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IBookBL
    {
        Task<List<BookDTO>> AddBook(BookDTO book);
        Task<List<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookById(int id);
        Task RemoveBook(int id);
        Task<BookDTO> UpdateBook(BookDTO book);
    }
}