using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface ILookUpBL
    {
        Task<List<LessonSubjectDTO>> GetAllLessonSubjects();
        Task<List<LessonTypeDTO>> GetAllLessonTypes();
        Task<List<ParashatShavuaDTO>> GetAllParashatShavuas();
    }
}