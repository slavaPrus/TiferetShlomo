using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IMarkDAL
    {
        Task<List<Mark>> AddMark(Mark mark);
        Task<List<Mark>> GetAllMarks();
        Task<List<Mark>> GetMarksByUserId(int id);
        Task RemoveMark(int id);
        Task<Mark> UpdateMark(Mark mark);
    }
}