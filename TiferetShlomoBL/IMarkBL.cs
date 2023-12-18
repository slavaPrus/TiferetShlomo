using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IMarkBL
    {
        void AddMark(MarkDTO mark);
        IEnumerable<MarkDTO> GetAllMarks();
        Mark GetMarkById(int id);
        void RemoveMark(int id);
        void UpdateMark(Mark mark);
    }
}