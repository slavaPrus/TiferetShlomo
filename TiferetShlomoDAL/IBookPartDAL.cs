using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IBookPartDAL
    {
        Task<List<BookPart>> AddBookPart(BookPart bookPart);
        Task<List<BookPart>> GetAllBookParts();
        Task<BookPart> GetBookPartById(int id);
        Task<BookPart> UpdateBookPart(BookPart bookPart);
        Task RemoveBookPart(int id);
    }
}