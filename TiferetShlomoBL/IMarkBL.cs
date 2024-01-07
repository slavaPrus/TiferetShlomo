using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IMarkBL
    {
        void AddMark(MarkDTO mark);
        IEnumerable<MarkDTO> GetAllMarks();
        MarkDTO GetMarkById(int id);
        void RemoveMark(int id);
        void UpdateMark(MarkDTO mark);
    }
}