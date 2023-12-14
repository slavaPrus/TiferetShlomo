using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface ILessonBL
    {
        void AddLesson(Lesson lesson);
        IEnumerable<Lesson> GetAllLessons();
        Lesson GetLessonById(int id);
        void RemoveLesson(int id);
        void UpdateLesson(Lesson lesson);
    }
}