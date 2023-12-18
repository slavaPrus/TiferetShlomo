using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IMarkDAL
    {
        void AddMark(Mark mark);
        IEnumerable<Mark> GetAllMarks();
        Mark GetMarkById(int id);
        void RemoveMark(int id);
        void UpdateMark(Mark mark);
    }
}