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
    }
}