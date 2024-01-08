using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomo.Controllers
{
    [Route("api/lookup")]
    [ApiController]
    public class LookUpController : ControllerBase
    {

        private readonly ILookUpBL _lookUpBL;

        public LookUpController(ILookUpBL lookUpBL)
        {
            _lookUpBL = lookUpBL;
        }

       
        [HttpGet("lessonTypes")]
        public async Task<List<LessonTypeDTO>> GetAllLessonTypes()
        {
            try
            {
                List<LessonTypeDTO> lessonTypes = await _lookUpBL.GetAllLessonTypes();
                return lessonTypes;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllLessonTypes Controller");
                      return null;
            }
        }

        [HttpGet("lessonSubjects")]
        public async Task<List<LessonSubjectDTO>> GetAllLessonSubjects()
        {
            try
            {
                List<LessonSubjectDTO> lessonSubjects = await _lookUpBL.GetAllLessonSubjects();
                return lessonSubjects;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllLessonSubjects Controller");
                return null;
            }
        }

        [HttpGet("parashatShavuas")]
        public async Task<List<ParashatShavuaDTO>> GetAllParashatShavuas()
        {
            try
            {
                List<ParashatShavuaDTO> parashatShavuas = await _lookUpBL.GetAllParashatShavuas();
                return parashatShavuas;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllParashatShavua Controller");
                return null;
            }
        }
    }
}
