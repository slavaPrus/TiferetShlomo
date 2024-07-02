using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface ILessonBL
    {
        Task<List<LessonDTO>> AddLesson(LessonDTO Lesson);
        Task<List<LessonDTO>> GetAllLessons();
        Task<LessonDTO> GetLessonById(int id);
        Task RemoveLesson(int id);
        Task<LessonDTO> UpdateLesson(LessonDTO Lesson);
        Task<(List<LessonDTO>, bool)> GetLessonsByPage(int page);
        Task<(List<LessonDTO>, bool)> GetSearchLessonsByPage(int page, string str);
        Task<(List<LessonDTO>, bool)> GetFilterLessonsByPage(int page, string str);
    }
}