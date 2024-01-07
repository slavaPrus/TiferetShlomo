using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface ILessonDAL
    {
        Task<List<Lesson>> AddLesson(Lesson Lesson);
        Task<List<Lesson>> GetAllLessons();
        Task<Lesson> GetLessonById(int id);
        Task RemoveLesson(int id);
        Task<Lesson> UpdateLesson(Lesson Lesson);
    }
}