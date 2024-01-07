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
    }
}
