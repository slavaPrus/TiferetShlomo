using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IBookPartDAL
    {
        void AddBookPart(BookPart bookPart);
        IEnumerable<BookPart> GetAllBookParts();
        BookPart GetBookPartById(int id);
        void RemoveBookPart(int id);
        void UpdateBookPart(BookPart bookPart);
    }
}