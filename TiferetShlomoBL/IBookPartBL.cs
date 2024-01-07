using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IBookPartBL
    {
        Task<List<BookPartDTO>> AddBookPart(BookPartDTO bookPart);
        Task<List<BookPartDTO>> GetAllBookParts();
        Task<BookPartDTO> GetBookPartById(int id);
        Task RemoveBookPart(int id);
        Task<BookPartDTO> UpdateBookPart(BookPartDTO bookPart);
    }
}