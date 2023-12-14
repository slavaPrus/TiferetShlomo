using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface ILessonDAL
    {
        void AddLesson(Lesson lesson);
        IEnumerable<Lesson> GetAllLessons();
        Lesson GetLessonById(int id);
        void RemoveLesson(int id);
        void UpdateLesson(Lesson lesson);
    }
}