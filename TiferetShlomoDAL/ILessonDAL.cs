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
        Task<(List<Lesson>, bool)> GetLessonsByPage(int skipCount, int pageSize);
        Task<(List<Lesson>, bool)> GetSearchLessonsByPage(int skipCount, int pageSize, string str);
        Task<(List<Lesson>, bool)> GetFilterLessonsByPage(int skipCount, int pageSize, string str);
    }
}