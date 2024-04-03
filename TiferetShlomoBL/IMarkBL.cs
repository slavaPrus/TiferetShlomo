using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IMarkBL
    {
        Task<List<MarkDTO>> AddMark(MarkDTO mark);
        Task<List<MarkDTO>> GetAllMarks();
        Task<List<MarkDTO>> GetMarksByUserId(int id);
        Task RemoveMark(int id);
        Task<MarkDTO> UpdateMark(MarkDTO mark);
    }
}