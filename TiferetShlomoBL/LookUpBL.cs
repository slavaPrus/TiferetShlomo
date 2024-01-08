using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiferetShlomoDAL;
using TiferetShlomoDTO.DTO;
using AutoMapper;
using System.Linq;

namespace TiferetShlomoBL
{
    public class LookUpBL : ILookUpBL
    {
        private readonly ILookUpDAL _lookUpDAL;
        private readonly IMapper _mapper;

        public LookUpBL(ILookUpDAL lookUpDAL, IMapper mapper)
        {
            _lookUpDAL = lookUpDAL;
            _mapper = mapper;
        }

        public async Task<List<LessonTypeDTO>> GetAllLessonTypes()
        {
            try
            {
                var lessonTypes = await _lookUpDAL.GetAllLessonTypes();
                return _mapper.Map<List<LessonTypeDTO>>(lessonTypes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllLessonTypes BL");
                return null;
            }
        }

        public async Task<List<LessonSubjectDTO>> GetAllLessonSubjects()
        {
            try
            {
                var lessonSubjects = await _lookUpDAL.GetAllLessonSubjects();
                return _mapper.Map<List<LessonSubjectDTO>>(lessonSubjects);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllLessonSubjects BL");
                return null;
            }
        }

        public async Task<List<ParashatShavuaDTO>> GetAllParashatShavuas()
        {
            try
            {
                var parashatShavuas = await _lookUpDAL.GetAllParashatShavuas();
                return _mapper.Map<List<ParashatShavuaDTO>>(parashatShavuas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllParashatShavuas BL");
                return null;
            }
        }
    }
}
