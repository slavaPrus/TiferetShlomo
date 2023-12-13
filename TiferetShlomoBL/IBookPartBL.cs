using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface IBookPartBL
    {
        void AddBookPart(BookPart bookPart);
        IEnumerable<BookPart> GetAllBookParts();
        BookPart GetBookPartById(int id);
        void RemoveBookPart(int id);
        void UpdateBookPart(BookPart bookPart);
    }
}