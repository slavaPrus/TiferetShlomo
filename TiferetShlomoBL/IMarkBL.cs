using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IMarkBL
    {
        Task<List<MarkDTO>> AddMark(MarkDTO mark);
        Task<List<MarkDTO>> GetAllMarks();
        Task<MarkDTO> GetMarkById(int id);
        Task RemoveMark(int id);
        Task<MarkDTO> UpdateMark(MarkDTO mark);
    }
}