using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;

namespace TiferetShlomoBL
{
    public class LessonBL : ILessonBL
    {
        private readonly ILessonDAL _LessonDAL;
        private readonly IMapper _mapper;

        public LessonBL(ILessonDAL LessonDAL, IMapper mapper)
        {
            _LessonDAL = LessonDAL;
            _mapper = mapper;
        }

        public async Task<List<LessonDTO>> GetAllLessons()
        {
            try
            {
                List<Lesson> Lessons = await _LessonDAL.GetAllLessons();

                List<LessonDTO> LessonsDTO = _mapper.Map<List<LessonDTO>>(Lessons);

                return LessonsDTO;

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllLessons BL");
                return null;
            }
        }

        public async Task<LessonDTO> GetLessonById(int id)
        {
            try
            {
                Lesson Lesson = await _LessonDAL.GetLessonById(id);
                LessonDTO LessonDTO = _mapper.Map<LessonDTO>(Lesson);
                return LessonDTO;

            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetLessonById BL");
                return null;
            }
        }

        public async Task<List<LessonDTO>> AddLesson(LessonDTO Lesson)
        {
            try
            {
                Lesson b = _mapper.Map<Lesson>(Lesson);
                List<Lesson> Lessons = await _LessonDAL.AddLesson(b);

                List<LessonDTO> LessonsDTO = _mapper.Map<List<LessonDTO>>(Lessons);

                return LessonsDTO;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "AddLesson BL");
                return null;
            }
        }

        public async Task<LessonDTO> UpdateLesson(LessonDTO Lesson)
        {
            try
            {
                Lesson b = _mapper.Map<Lesson>(Lesson);
                Lesson bUP = await _LessonDAL.UpdateLesson(b);
                LessonDTO btd = _mapper.Map<LessonDTO>(bUP);
                return btd;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "UpdateLesson BL");
                return null;
            }
        }

        public async Task RemoveLesson(int id)
        {
            try
            {
                await _LessonDAL.RemoveLesson(id);
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "RemoveLesson BL");

            }
        }

        public async Task<(List<LessonDTO>, bool)> GetLessonsByPage(int page)
        {
            try
            {
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;
                // Retrieve Lessons from the repository based on skipCount and pageSize
                (List<Lesson> lessons, bool hasNext) = await _LessonDAL.GetLessonsByPage(skipCount, pageSize);

                List<LessonDTO> lessonsDTO = _mapper.Map<List<LessonDTO>>(lessons);

                return (lessonsDTO, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetLessonsByPage in LessonBL");
                return (null, false); 
                // Propagate the exception to the controller for centralized error handling
            }
        }
        public async Task<(List<LessonDTO>, bool)> GetSearchLessonsByPage(int page, string str)
        {
            try
            {
                //int pageSize = 16;
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;
                // Retrieve books from the repository based on skipCount and pageSize
                (List<Lesson> lessons, bool hasNext) = await _LessonDAL.GetSearchLessonsByPage(skipCount, pageSize, str);

                List<LessonDTO> lessonsDTO = _mapper.Map<List<LessonDTO>>(lessons);

                return (lessonsDTO, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetSearchLessonsByPage in LessonBL");
                return (null, false); // Propagate the exception to the controller for centralized error handling
            }
        }
        public async Task<(List<LessonDTO>, bool)> GetFilterLessonsByPage(int page, string str)
        {
            try
            {
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;

                // Retrieve filtered books from the DAL layer along with the hasNext flag
                (List<Lesson> filteredLessons, bool hasNext) = await _LessonDAL.GetFilterLessonsByPage(skipCount, pageSize, str);

                List<LessonDTO> lessonsDTO = _mapper.Map<List<LessonDTO>>(filteredLessons);

                return (lessonsDTO, hasNext);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFilterLessonsByPage in LessonBL");
                return (null, false); // Propagate the exception to the controller for centralized error handling
            }
        }

    }
}

