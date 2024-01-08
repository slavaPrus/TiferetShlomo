using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface ILookUpDAL
    {
        Task<List<LessonSubject>> GetAllLessonSubjects();
        Task<List<LessonType>> GetAllLessonTypes();
        Task<List<ParashatShavua>> GetAllParashatShavuas();
    }
}